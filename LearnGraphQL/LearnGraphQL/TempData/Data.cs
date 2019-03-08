using LearnGraphQL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnGraphQL.TempDate
{
    public class Data
    {
        private List<Book> books;
        private List<Author> authors;
        public Data()
        {
            #region books init
            books = new List<Book>();
            books.Add(new Book()
            {
                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = 1,
                Name = "吞噬星空",
                Price = 1.2m,
                AuthorId = 1
            });
            books.Add(new Book()
            {

                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = 2,
                Name = "斗破苍穹",
                Price = 2.2m,
                AuthorId = 4
            });
            books.Add(new Book()
            {

                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = 3,
                Name = "雪中悍刀行",
                Price = 3.2m,
                AuthorId = 1
            });
            books.Add(new Book()
            {

                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = 4,
                Name = "完美世界",
                Price = 4.2m,
                AuthorId = 2
            });
            books.Add(new Book()
            {

                CreatedAt = DateTime.Now,
                Deleted = false,
                Id = 5,
                Name = "盗墓笔记",
                Price = 5.2m,
                AuthorId = 3
            });
            #endregion

            #region authors init
            authors = new List<Author>();
            authors.Add(new Author() { Age = 1, CreatedAt = DateTime.Now, Deleted = false, Id = 1, Name = "我吃西红柿" });
            authors.Add(new Author() { Age = 11, CreatedAt = DateTime.Now, Deleted = false, Id = 2, Name = "辰东" });
            authors.Add(new Author() { Age = 21, CreatedAt = DateTime.Now, Deleted = false, Id = 3, Name = "南派三叔" });
            authors.Add(new Author() { Age = 31, CreatedAt = DateTime.Now, Deleted = false, Id = 4, Name = "天蚕土豆" });
            #endregion
        }
        public IEnumerable<Book> GetBooks()
        {
            return books.AsEnumerable();
        }

        public Book InsertBook(Book book)
        {
            books.Add(book);
            return book;
        }

        public IEnumerable<Author> GetAuthors()
        {
            return authors.AsEnumerable();
        }
    }
}
