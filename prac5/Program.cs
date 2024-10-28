using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HashPassword;
using prac5.Models;

namespace prac5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (construction_organizationEntities1 context = Helper.GetContext())
            {
                try
                {
                    Authtorizations autht = new Authtorizations();
                    Users user = new Users();
                    Console.WriteLine("Введите логин: ");
                    autht.login = Console.ReadLine();
                    Console.WriteLine("Придумайте пароль: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Повторите пароль: ");
                    string repitePswd = Console.ReadLine();

                    if (repitePswd != password)
                    {
                        Console.WriteLine("Пароли не совпадают, попробуйте снова");
                    }
                    else
                    {
                        autht.password = HashSHA256.HashPswd(password);
                        Console.WriteLine($"Ваш хэшированный пароль пользователя: {autht.password}");
                    }
                    Console.WriteLine("Введите ваше имя: ");
                    user.name = Console.ReadLine();

                    Console.WriteLine("Введите вашу фамилию: ");
                    user.surname = Console.ReadLine();

                    Console.WriteLine("Введите вашу электронную почту: ");
                    user.email = Console.ReadLine();

                    context.Users.Add(user);
                    


                    int newID = user.id;
                    autht.id = newID;
                    context.Authtorizations.Add(autht);

                    context.SaveChangesAsync();

                    Console.WriteLine("Новый пользователь успешно добавлен в базу данных!");
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadKey();
            }
        }
    }
}
