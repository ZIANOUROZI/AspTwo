using AspTwo.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspTwo.Controllers
{
    //Tänk mig att jag är lärare på en skola och är ansvar för att hantera information om eleverna och deras läxor Min (TeacherCotroller) Är min verktygslåda 
    //Som innehåller alla verktyg jag behöver för att hantera alla elever och deras läxor
    public class TeacherController : Controller //Detta är som min verktygslåda som innehåller alla min verktyg som ska hantera läxor och elever
    {
        private readonly ApplicationDbContext _context; // Detta är som en bok där jag skriver ner alla läxor och info om elever (ApplicationDbContext) hjälper mig att att
        //spara och hämta denna information från databas
       public TeacherController(ApplicationDbContext context) // Och nu när jag börjar mitt arbete som lärare behöver denna bok för att veta vilka läxor eleverna har och andra
            //viktiga detaljer. Jag ber en bok från skolans kontor (ApplicatuonDbContext)
        {
            _context = context; //När jag får boken från skolans kontor hållar jag den nära mig för att kunna tita i den när jag behöver veta vilken elever eller annan viktigt info
        }
    }
}
