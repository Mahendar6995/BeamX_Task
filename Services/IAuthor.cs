using BeamX_Task.Models;

namespace BeamX_Task.Services
{
    public interface IAuthor
    {
        public string Save(Author author);
        public string Delete(int id);
        public Author GetAuthorById(int id);
        public string Update(Author author);
        public List<Author> GetAllAuthors();

    }
}
