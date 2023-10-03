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
                var mentorRepository = scope.ServiceProvider.GetRequiredService<MentorRepository>();
                Mentor mentor = new Mentor();
                mentor.name="Naman";
                mentor.email = "Naman@scaler.com";
                mentor.averageRating=4.65;
                mentorRepository.Add(mentor);

                var userRepository = scope.ServiceProvider.GetRequiredService<UserRepository>();
                User user = new User();
                user.name = "Prasanna";
                user.email = "sarathcool@yopmail.com";
                userRepository.Add(user);
                // Test your repository methods here
                //var tas = await taRepository.GetAllTAsAsync();
                //foreach (var ta in tas)
                //{
                //    Console.WriteLine($"Id: {ta.Id}, Name: {ta.Name}, Email: {ta.Email}, AverageRating: {ta.AverageRating}");
                //}
            }
        }
    }
}
