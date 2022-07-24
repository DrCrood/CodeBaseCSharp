using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CodeBase
{
    public class BookShelf : IEnumerable, IComparable
    {
        public string Position { get; set; }
        private List<Book> Books = new List<Book>();

        public BookShelf()
        {
            Books.Add(new Book() { Price = 100, Title = "First legend" });
            Books.Add(new Book() { Price = 200, Title = "Second legend" });
            Books.Add(new Book() { Price = 300, Title = "Third legend" });
            Books.Add(new Book() { Price = 400, Title = "Fourth legend" });
            Books.Add(new Book() { Price = 150, Title = "First-2 legend" });
            Books.Add(new Book() { Price = 250, Title = "Second-2 legend" });
            Books.Add(new Book() { Price = 350, Title = "Third-2 legend" });
            Books.Add(new Book() { Price = 450, Title = "Fourth-2 legend" });

            Books.Sort();
        }

        public IEnumerable<Book> GetBooks()
        {
            return Books;
        }

        public IEnumerator GetEnumerator()
        {
            return Books.GetEnumerator();
        }

        public IEnumerable<Book> GetNextBook()
        {
            foreach (Book b in Books)
            {
                yield return b;
            }
        }

        public IEnumerable<Book> GetNextHighBook()
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Price > 200)
                {
                    yield return Books[i];
                }
            }
        }

        public int CompareTo(object o)
        {
            BookShelf sf = o as BookShelf;
            if (sf == null)
            {
                return -1;
            }

            if (this.Position == sf.Position)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public Book this[string title]
        {
            get => GetBookWithTitle(title);
        }

        public Book GetBookWithTitle(string title)
        {
            foreach (Book b in Books)
            {
                if (b.Title == title)
                {
                    return b;
                }
            }
            return new Book();
        }

    }

    public class Book : IComparable
    {
        public int Price { get; set; }
        public string Title { get; set; }

        public int CompareTo(object o)
        {
            Book bk = o as Book;
            if (bk == null)
            {
                return -1;
            }

            if (this.Price == bk.Price)
            {
                return 0;
            }
            else if (this.Price > bk.Price)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

}
