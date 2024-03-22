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
        public string Delete(int id)
        {
            Author DeleteAuthor=GetAuthorById(id); 

            if(DeleteAuthor!=null)
            {
                ctx.Authors.Remove(DeleteAuthor);
                int rowsupdated= ctx.SaveChanges();
                if(rowsupdated>0)
                {
                    return "Data Deleted Successfully!!!";
                }
            }
            return "Something went Wrong!!!";
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

        public string Save(Author author)
        {
            ctx.Authors.Add(author);
            int rowsupdated = ctx.SaveChanges();
            if(rowsupdated>0)
            {
                return "Data Saved Successfully!!!";
            }

            return "Sometghing went Wrong!!!";
        }

        public string Update(Author author)
        {
            ctx.Authors.Update(author);
            int rowsupdated = ctx.SaveChanges();
            if (rowsupdated > 0)
            {
                return "Data Updated Successfully!!!";
            }

            return "Sometghing went Wrong!!!";
        }
    }
}
