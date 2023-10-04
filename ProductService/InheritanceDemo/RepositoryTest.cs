using ProductService.InheritanceDemo.TablePerHierarchy;

namespace ProductService.InheritanceDemo
{
    public class RepositoryTest
    {
        private readonly IServiceProvider _serviceProvider;
        public RepositoryTest(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void RunRepositoryTests()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var mentorRepository = scope.ServiceProvider.GetRequiredService<InheritanceDemo.TablePerHierarchy.MentorRepository>();
                InheritanceDemo.TablePerHierarchy.Mentor mentor = new InheritanceDemo.TablePerHierarchy.Mentor();
                mentor.name="Naman";
                mentor.email = "Naman@scaler.com";
                mentor.averageRating=4.65;
                mentorRepository.Add(mentor);

                var userRepository = scope.ServiceProvider.GetRequiredService<InheritanceDemo.TablePerHierarchy.UserRepository>();
                InheritanceDemo.TablePerHierarchy.User user = new InheritanceDemo.TablePerHierarchy.User();
                user.name = "Prasanna";
                user.email = "sarathcool@yopmail.com";
                userRepository.Add(user);


                // Test your repository methods here
                //var tas = await taRepository.GetAllTAsAsync();
                //foreach (var ta in tas)
                //{
                //    Console.WriteLine($"Id: {ta.Id}, Name: {ta.Name}, Email: {ta.Email}, AverageRating: {ta.AverageRating}");
                //}


                var mentorRepository2 = scope.ServiceProvider.GetRequiredService<InheritanceDemo.TablePerConcreteType.MentorRepository>();
                InheritanceDemo.TablePerConcreteType.Mentor mentor2 = new InheritanceDemo.TablePerConcreteType.Mentor();
                mentor2.name = "NamanTPC";
                mentor2.email = "Naman@scaler.com";
                mentor2.averageRating = 4.65;
                mentorRepository2.Add(mentor2);

                var mentorRepository3 = scope.ServiceProvider.GetRequiredService<InheritanceDemo.TablePerType.MentorRepository>();
                InheritanceDemo.TablePerType.Mentor mentor3 = new InheritanceDemo.TablePerType.Mentor();
                mentor3.name = "NamanTPT";
                mentor3.email = "Naman@scaler.com";
                mentor3.averageRating = 4.65;
                mentorRepository3.Add(mentor3);
            }
        }
    }
}
