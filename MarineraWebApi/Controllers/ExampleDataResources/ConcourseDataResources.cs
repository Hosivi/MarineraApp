using Domain.Aggregates;

namespace MarineraWebApi.Controllers.ExampleDataResources;

public class ConcourseDataResources
{
    public static List<Concourse>  GetConcourses()
    {
        Random random = new Random();
        List<Concourse> concourses = new List<Concourse>();

        for (int i = 0; i < 10; i++) // Crear 10 objetos Concourse
        {
            var concourse = new Concourse($"Concourse {i + 1}", new DateTime(){})
            {
                
                Description = $"Description for Concourse {i + 1}",
                PhoneNumber = $"123-456-{i + 1:D4}", // Generar un número de teléfono aleatorio
                OpeningTime = TimeSpan.FromHours(random.Next(24)), // Generar una hora de apertura aleatoria
                ClosingTime = TimeSpan.FromHours(random.Next(24)), // Generar una hora de cierre aleatoria
                AdressLine1 = $"Address Line 1 for Concourse {i + 1}",
                AdressLine2 = $"Address Line 2 for Concourse {i + 1}",
                District = $"District {i + 1}",
                // Deberías crear instancias de Organization, TicketOffice y RegisterOffice aquí,
                // pero por simplicidad, los dejaremos como null.
                Organization = null,
                TicketOffice = null,
                RegisterOffice = null
            };

            concourses.Add(concourse);
        }
        return concourses;
    }
    

}