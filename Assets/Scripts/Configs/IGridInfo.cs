namespace Configs
{
    public interface IGridInfo<out T>
    {
        int GetId();
        int GetCount();
        void SetCount(int value);
        T GetSelf();
    }

    public class GameItem:IGridInfo<GameItem>
    {
        public int Id;
        public string ItemName;
        public string ItemType;
        public string ItemDes;
        public string ItemImagePath;
        public int LimitedSize;
        public int Count;
        public int GetId()
        {
            return Id;
        }

        public int GetCount()
        {
            return Count;
        }

        public void SetCount(int value)
        {
            Count = value;
        }

        public GameItem GetSelf()
        {
            return this;
        }
    }
}