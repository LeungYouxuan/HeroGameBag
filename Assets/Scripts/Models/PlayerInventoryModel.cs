using System.Collections.Generic;
using System.Data;
using Configs;
using Managers;
using Mono.Data.Sqlite;
using QFramework;
using UnityEngine;

namespace Models
{
    public class PlayerInventoryModel:AbstractModel
    {
        public List<IGridInfo<GameItem>> PlayerGameItems;
        public SqliteConnection Connection;
        protected override void OnInit()
        {
            PlayerGameItems = new List<IGridInfo<GameItem>>();
            Connection = new SqliteConnection(InitManager.Instance.dataBasePath);
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
                Debug.Log("<color=green>连接到数据库成功</color>");
            }
            else
            {
                Debug.Log("<color=red>连接到数据库失败</color=green>");
            }
        }
    }
    public class GetGameItemQuery : AbstractQuery<GameItem>
    {
        private int _id;

        public GetGameItemQuery(int id)
        {
            _id = id;
        }

        protected override GameItem OnDo()
        {
            var model = this.GetModel<PlayerInventoryModel>();
            if (model.Connection.State == ConnectionState.Closed) 
                model.Connection.Open();  // 确保连接是打开的
        
            string query = $"SELECT * FROM Item WHERE ItemID = {_id}";
            using (SqliteCommand command = new SqliteCommand(query, model.Connection))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // 读取数据库中的各列并映射到GameItem对象
                        GameItem item = new GameItem
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("ItemID")),
                            ItemName = reader.GetString(reader.GetOrdinal("ItemName")),
                            ItemType = reader.GetString(reader.GetOrdinal("ItemType")),
                            LimitedSize = reader.GetInt32(reader.GetOrdinal("LimitedSize")),
                            ItemImagePath = reader.GetString(reader.GetOrdinal("ItemImagePath")),
                            ItemDes = reader.GetString(reader.GetOrdinal("ItemDes")),
                            Count = 1 // 默认为1，或根据你的需求进行调整
                        };
                        return item;
                    }
                }
            }
            return null; // 如果没有找到记录，返回null
        }
    }

}