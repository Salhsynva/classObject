using System;

namespace classproject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region task 1, 2
            //Notebook notebook1 = new Notebook
            //{
            //    Name = "vivobook",
            //    BrandName = "ASUS",
            //    Price = 1600
            //};

            //Notebook notebook2 = new Notebook();
            //notebook2.Name = "pavilion";
            //notebook2.BrandName = "hd";
            //notebook2.Price = 2000;



            //Notebook[] notebooks = { notebook1, notebook2 };

            //Console.WriteLine("minimum qiymeti daxil edin:");
            //string minPricestr = Console.ReadLine();
            //double minPrice = Convert.ToInt32(minPricestr);
            //Console.WriteLine("maksimum qiymeti daxil edin:");
            //string maxPricestr = Console.ReadLine();
            //double maxPrice = Convert.ToInt32(maxPricestr);

            //Notebook[] newNotebooks = NotebookArray(notebooks, minPrice, maxPrice);

            //foreach (var item in newNotebooks)
            //{
            //    Console.WriteLine($"notebookun adi: {item.Name}, notebookun brand adi: {item.BrandName}, notebookun qiymeti: {item.Price}");
            //}
            #endregion

            #region task 3 
            Console.WriteLine("nece kitab isteyirsiniz?");
            string sizestr = Console.ReadLine();
            int size = Convert.ToInt32(sizestr);
            while (size <= 0)
            {
                Console.WriteLine($"kitab sayi {size} ola bilmez");
                size = Convert.ToInt32(Console.ReadLine());
            }

            Library library1 = new Library
            {
                Books = new Book[size]
            };


            for (int i = 0; i < size; i++)
            {
                int no;
                string name;
                string genre;
                double price;
                int count;
                do
                {
                    Console.WriteLine($"{i+1}. kitabin nomresini daxil edin:");
                    no = Convert.ToInt32(Console.ReadLine());
                    if (no < 0)
                    {
                        Console.WriteLine("no deyeri menfi ola bilmez!");
                    }
                    for (int j = 0; j < i; j++)
                    {
                        if (i!=j && no == library1.Books[j].No)
                        {
                            Console.WriteLine("eyni nomre deyerinde 2ci kitab elave edile bilmez!");
                            no = Convert.ToInt32(Console.ReadLine());
                        }
                        
                    }
                } while (no < 0);
                  
                Console.WriteLine($"{i + 1}. kitabin adini daxil edin:");
                name = Console.ReadLine();
                while (name.Length < 0 || name.Length > 50)
                {
                    Console.WriteLine("kitabin adinin uzunlugu 1-dən kiçik və 50-dən böyük ola bilməz");
                    name = Console.ReadLine();
                }

                Console.WriteLine($"{i + 1}. kitabin janrini daxil edin:");
                genre = Console.ReadLine();
                while (genre.Length < 3 || genre.Length > 30)
                {
                    Console.WriteLine("kitabin janr adinin uzunlugu 3-dən kiçik və 30-dan böyük ola bilməz");
                    genre = Console.ReadLine();
                }

                Console.WriteLine($"{i+1}. kitabin qiymetini daxil edin: ");
                price = Convert.ToDouble(Console.ReadLine());
                while (price < 0)
                {
                    Console.WriteLine("kitabin qiymeti 0-dan kicik ola bilmez");
                    price = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine($"{i+1}. kitabin sayini daxil edin: ");
                count = Convert.ToInt32(Console.ReadLine());
                while (count < 0)
                {
                    Console.WriteLine("kitabin sayi 0-dan kicik ola bilmez");
                    count = Convert.ToInt32(Console.ReadLine());
                }
                Book book = new Book(genre, no, name, price)
                {
                    Count = count
                };

                library1.Books[i] = book;

                Console.WriteLine("-----------------------------------------------------------------------");
            }
            char answer;
            int num = 1;
            char answer2;
            string genreForFilter;
            int minPrice;
            int maxPrice;
            do
            {
                Console.WriteLine("filterlemek isteyirsinizmi?");
                Console.WriteLine("beli: y | xeyr: n");
                answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'n')
                {
                    foreach (var item in library1.Books)
                    {
                        Console.WriteLine($"{num}. kitabin adi: {item.Name}, janri: {item.Genre}, nomresi: {item.No}, qiymeti: {item.Price}, sayi: {item.Count}.");
                    }
                }
                else if (answer == 'y')
                {
                    do
                    {
                        Console.WriteLine("1 - Genre adina gore , 2 - Qiymet intervalina gore");
                        answer2 = Convert.ToChar(Console.ReadLine());
                        if (answer2 == '1')
                        {
                            Console.WriteLine("hansi janri axtarirsiniz?");
                            genreForFilter = Console.ReadLine();
                            library1.GetFilteredBooks(library1.Books, genreForFilter);
                        }
                        else if (answer2 == '2')
                        {
                            Console.WriteLine("minimum qiymeti daxil edin: ");
                            minPrice = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("maksimum qiymeti daxil edin: ");
                            maxPrice = Convert.ToInt32(Console.ReadLine());
                            library1.GetFilteredBooks(library1.Books, minPrice, maxPrice);
                        }
                    } while (answer2 != '1' && answer2 != '2');
                }
            } while (answer != 'y' && answer!='n');

            #endregion
        }

        static Notebook[] NotebookArray(Notebook[] array, double minPrice, double maxPrice)
        {
            int count = 0;
            foreach (var item in array)
            {
                if (item.Price > minPrice && item.Price < maxPrice)
                    count++;
            }
            Notebook[] newNotebooks = new Notebook[count];
            int j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Price > minPrice && array[i].Price < maxPrice)
                {
                    newNotebooks[i] = array[i];
                    j++;
                }
            }
            return newNotebooks;
        }

        
    }
}
