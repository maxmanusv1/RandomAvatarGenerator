using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageGenerator.Keywords
{
    public class KeywordGenerator
    {
        Random random = new Random();
        public async Task<string> GetFamousNamesAsync()
        {
            List<string> famousNames = new List<string> {
            "Beyoncé", "Leonardo DiCaprio", "Taylor Swift", "Brad Pitt", "Rihanna",
            "Will Smith", "Jennifer Lopez", "Tom Cruise", "Angelina Jolie", "Kanye West",
            "Oprah Winfrey", "Justin Bieber", "Kim Kardashian", "Elon Musk", "Lady Gaga",
            "Cristiano Ronaldo", "Beyazıt Öztürk", "Bill Gates", "Emma Watson", "Selena Gomez",
            "Adele", "Johnny Depp", "Katy Perry", "Hugh Jackman", "Meryl Streep",
            "Shakira", "Robert Downey Jr.", "Scarlett Johansson", "Eminem", "Jennifer Aniston",
            "Mark Zuckerberg", "Beyaz Show", "Donald Trump", "Tom Hanks", "Keanu Reeves",
            "Gisele Bündchen", "David Beckham", "Ellen DeGeneres", "Celine Dion", "Michael Jordan",
            "George Clooney", "Julia Roberts", "Jamie Foxx", "Kate Winslet", "Natalie Portman",
            "Jay-Z", "Priyanka Chopra", "Serena Williams", "Ellen Pompeo", "Mark Wahlberg",
            "Gwyneth Paltrow", "Ryan Reynolds", "Ed Sheeran", "Sandra Bullock", "Ryan Gosling",
            "Reese Witherspoon", "Jennifer Lawrence", "Drake", "LeBron James", "Meghan Markle",
            "Daniel Craig", "J.K. Rowling", "Michael Phelps"
            };
            return  famousNames[random.Next(famousNames.Count)];
        }
        public async Task<string> GetAnimePromptAsync()
        {
            Random random = new Random();
            List<string> similarWords = new List<string> {
            "woman, brunette, jade eyes, kaleidoscopic, autumn",
            "girl, chestnut hair, hazel eyes, diverse, vibrant",
            "lady, green eyes, auburn hair, colorful, vivid",
            "female, dark hair, gray eyes, dynamic, radiant",
            "maiden, brown eyes, multicolored, lively, seasonal",
            "daughter, black hair, amber eyes, rich, picturesque",
            "sister, blond hair, blue eyes, effervescent, picturesque",
            "mother, red hair, emerald eyes, intricate, seasonal",
            "wife, silver hair, turquoise eyes, vibrant, transitional",
            "girlfriend, platinum hair, sapphire eyes, effervescent, captivating",
            "aunt, golden hair, aquamarine eyes, vibrant, enchanting",
            "niece, copper hair, indigo eyes, dynamic, alluring",
            "grandmother, mahogany hair, violet eyes, radiant, scenic",
            "cousin, sandy hair, topaz eyes, kaleidoscopic, enchanting",
            "friend, chestnut hair, amber eyes, vibrant, picturesque",
            "colleague, chocolate hair, hazel eyes, dynamic, effervescent",
            "teacher, ebony hair, olive eyes, wise, serene",
            "student, chestnut hair, chestnut eyes, eager, ambitious",
            "doctor, platinum hair, steel-gray eyes, dedicated, knowledgeable",
            "nurse, auburn hair, emerald eyes, caring, compassionate",
            "scientist, silver hair, azure eyes, analytical, innovative",
            "artist, rainbow hair, expressive eyes, creative, imaginative",
            "musician, jet-black hair, piercing eyes, melodious, soulful",
            "actor, fiery hair, intense eyes, dramatic, charismatic",
            "writer, midnight hair, mysterious eyes, imaginative, eloquent",
            "poet, silver-white hair, dreamy eyes, lyrical, contemplative",
            "athlete, sun-kissed hair, determined eyes, agile, resilient",
            "chef, chestnut hair, sparkling eyes, culinary, inventive",
            "engineer, raven hair, calculating eyes, precise, innovative",
            "architect, platinum hair, visionary eyes, structural, creative",
            "designer, pastel hair, eclectic eyes, artistic, stylish",
            "entrepreneur, honey-colored hair, sharp eyes, ambitious, resourceful",
            "leader, salt-and-pepper hair, piercing eyes, decisive, inspiring",
            "innovator, platinum-blonde hair, futuristic eyes, groundbreaking, inventive",
            "pioneer, gray hair, penetrating eyes, trailblazing, resilient",
            "explorer, windswept hair, adventurous eyes, intrepid, curious",
            "adventurer, tousled hair, daring eyes, fearless, bold",
            "dreamer, silver-streaked hair, starry eyes, imaginative, visionary",
            "wanderer, unkempt hair, wanderlust-filled eyes, nomadic, free-spirited",
            "traveler, sun-bleached hair, wanderlust-filled eyes, globetrotting, adventurous",
            "seeker, wild hair, searching eyes, introspective, inquisitive",
            "philosopher, grizzled hair, wise eyes, contemplative, profound",
            "sage, silvered hair, serene eyes, knowledgeable, sagacious",
            "mentor, gray-streaked hair, guiding eyes, wise, supportive"
             };
            return similarWords[random.Next(similarWords.Count)];
        }
        public async Task<string> GetGameCharacterAsync()
        {
           
            List<string> oyunKarakterleri = new List<string>()
            {
                "Mario",
                "Lara Croft",
                "Master Chief",
                "Sonic the Hedgehog",
                "Kratos",
                "Samus Aran",
                "Link",
                "Princess Peach",
                "Nathan Drake",
                "Geralt of Rivia",
                "Solid Snake",
                "Cloud Strife",
                "Donkey Kong",
                "Doomguy",
                "Mega Man",
                "Pac-Man",
                "Duke Nukem",
                "Cortana",
                "Agent 47",
                "Commander Shepard",
                "Ezio Auditore",
                "Gordon Freeman",
                "Altaïr Ibn-La'Ahad",
                "Ellie",
                "Marcus Fenix",
                "Trevor Phillips",
                "CJ (Carl Johnson)",
                "Niko Bellic",
                "Clementine",
                "Spyro the Dragon",
                "Crash Bandicoot",
                "Sephiroth",
                "Aloy",
                "Isaac Clarke",
                "Ezreal",
                "Ryu",
                "Ken Masters",
                "Chun-Li",
                "Sub-Zero",
                "Scorpion",
                "Shovel Knight",
                "Eivor Varinsdottir",
                "Sora",
                "Yuna",
                "Tidus",
                "Aerith Gainsborough",
                "Yoshi",
                "Kerrigan",
                "Lúcio"
            };
            return oyunKarakterleri[random.Next(oyunKarakterleri.Count)];
        }
        public async Task<string> GetSentences()
        {
            List<string> sentences = new List<string>()
            {
                "A mermaid is playing the piano in a sunken ship.",
                "A wizard is brewing potions in a flying castle.",
                "A robot is surfing on Jupiter's giant storm.",
                "A pirate is searching for treasure in a haunted jungle.",
                "A superhero is racing a cheetah in a futuristic city.",
                "A vampire is hosting a tea party on a haunted train.",
                "A time traveler is attending a disco party in ancient Egypt.",
                "A dragon is knitting sweaters on top of a snowy mountain.",
                "An alien is playing basketball with the moon as the hoop.",
                "A fairy is riding a unicorn through a rainbow in outer space.",
                "A ninja is meditating under a waterfall in a bamboo forest.",
                "A samurai is battling a giant octopus in a sushi restaurant.",
                "A cowboy is herding robotic cattle on a neon-lit prairie.",
                "A chef is cooking pancakes on the back of a fire-breathing dragon.",
                "A scientist is conducting experiments inside a tornado.",
                "A musician is playing a saxophone on the rings of Saturn.",
                "A detective is solving mysteries in a town inhabited by ghosts.",
                "A cyborg is racing against a supersonic train on a hoverboard.",
                "A werewolf is howling at a neon moon in a cyberpunk city.",
                "A caveman is painting cave art on the walls of a spaceship.",
                "A sorcerer is casting spells at a magic academy for robots.",
                "A surfer is riding waves made of liquid gold in a desert oasis.",
                "A knight is jousting with a dragon in a medieval tournament.",
                "A spy is infiltrating a secret base hidden inside a volcano.",
                "A pilot is flying a hot air balloon made of candy over a candyland.",
                "A fisherman is angling for starfish in a cosmic ocean.",
                "A gardener is growing flowers on a floating island in the sky.",
                "A baker is baking bread in an enchanted forest bakery.",
                "A diver is exploring a sunken city beneath an iceberg.",
                "A snowman is melting in the heat of a volcano's eruption.",
                "A zookeeper is caring for robotic animals in a virtual zoo.",
                "A mechanic is repairing a spaceship on the surface of Mars.",
                "A poet is reciting poetry to a group of extraterrestrial beings.",
                "A painter is creating masterpieces on the surface of the moon.",
                "A dancer is performing ballet on the branches of a giant tree.",
                "A firefighter is extinguishing flames in a burning skyscraper.",
                "A baker is baking cookies in an oven powered by solar energy.",
                "A gardener is planting seeds in a garden on the edge of the universe.",
                "A magician is pulling rabbits out of a hat made of stardust.",
                "A swimmer is swimming in a pool filled with liquid gold.",
                "A climber is scaling a mountain made entirely of glass.",
                "A farmer is harvesting crops in a field on the surface of Mars.",
                "A chef is cooking gourmet meals in a restaurant at the bottom of the ocean.",
                "A musician is playing a harp on a cloud floating in the sky.",
                "A dancer is performing a traditional dance on the surface of a comet.",
                "A firefighter is rescuing cats from trees in a forest of candy canes.",
                "A scientist is conducting experiments in a laboratory hidden inside a volcano.",
                "An explorer is mapping uncharted territories in a jungle filled with dinosaurs."
            };
            return sentences[random.Next(sentences.Count)];
        }
    }
}
