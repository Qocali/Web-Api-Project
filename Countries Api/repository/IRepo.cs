namespace Countries_Api.repository
{
    public interface IRepo <T>
    {
        IEnumerable<T> GetAll();
        T GetbyId(int? id);
        void Create(T t);
        void Delate(int? id);
        void Update(int? id,T t);
    }
}
