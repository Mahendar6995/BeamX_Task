using BeamX_Task.Models;

namespace BeamX_Task.Services
{
    public interface IAuthor
    {
        public void Save(Author author);
        public void Delete(int id);
        public Author GetAuthorById(int id);
        public void Update(Author author);
        public List<Author> GetAllAuthors();

    }
}
