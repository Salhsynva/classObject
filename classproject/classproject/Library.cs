using System;
using System.Collections.Generic;
using System.Text;

namespace classproject
{
    class Library
    {
        public Book[] Books;
        
        public void AddBook(Book[] books, Book book)
        {
            int length = books.Length + 1;
            Book[] newBooks = new Book[length];
            newBooks[length - 1] = book;
            books = newBooks;
        }

        public void GetFilteredBooks(Book[] books, string genre)
        {
            int count = 0;
            foreach (var item in books)
            {
                if (item.Genre == genre)
                    count++;
            }
            Book[] sameGanreBooks = new Book[count];
            int j = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Genre == genre)
                {
                    sameGanreBooks[j] = books[i];
                    j++;
                }
            }
            foreach (var item in sameGanreBooks)
            {
                Console.WriteLine($"kitabin nomresi: {item.No}, kitabin adi: {item.Name}, kitabin janri: {item.Genre}, kitabin qiymeti: {item.Price}" );
            }
        }

        public void GetFilteredBooks(Book[] books, double minPrice, double maxPrice)
        {
            int count = 0;
            foreach (var item in books)
            {
                if (item.Price > minPrice && item.Price < maxPrice)
                    count++;
            }
            Book[] newBooks = new Book[count];
            int j = 0;
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].Price > minPrice && books[i].Price < maxPrice)
                {
                    newBooks[i] = books[i];
                    j++;
                }
            }
            foreach (var item in newBooks)
            {
                Console.WriteLine($"kitabin nomresi: {item.No}, kitabin adi: {item.Name}, kitabin janri: {item.Genre}, kitabin qiymeti: {item.Price}");
            }
        }
    }
}
