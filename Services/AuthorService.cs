using BeamX_Task.Context;
using BeamX_Task.Models;

namespace BeamX_Task.Services
{
    public class AuthorService : IAuthor
    {
        private MyDbContext ctx;

        public AuthorService(MyDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Delete(int id)
        {
            Author DeleteAuthor=GetAuthorById(id); 

            if(DeleteAuthor!=null)
            {
                ctx.Authors.Remove(DeleteAuthor);
                ctx.SaveChanges();
            }
        }

        public List<Author> GetAllAuthors()
        {
            List<Author> AuthorsList = ctx.Authors.ToList();
            return AuthorsList; 
        }

        public Author GetAuthorById(int id)
        {
            Author author = ctx.Authors.Where(val=>val.AuthorId==id).FirstOrDefault();
            return author;
        }

        public void Save(Author author)
        {
            ctx.Authors.Add(author);
            ctx.SaveChanges();
        }

        public void Update(Author author)
        {
            ctx.Authors.Update(author);
            ctx.SaveChanges();
        }
    }
}
