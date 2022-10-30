using SimpleStoreWeb.Data.Entities;
using System.Collections.Generic;

namespace SimpleStoreWeb.Extensions
{
    public static class PredefinedProducts
    {
        public static List<Product> CreateSeed(this List<Product> product)
        {
                product = new List<Product>()
                {
                    // user/rock
                    new Product()
                    {
                        Name = "Pink Floyd (The Dark Site Of The Moon)",
                        Description = "The Dark Side of the Moon is the eighth studio album by the English rock band Pink Floyd, released on 1 March 1973 by Harvest Records.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Rush (2112)",
                        Description = "2112 is the fourth studio album by Canadian rock band Rush, released on 1 April 1976 by Anthem Records. Rush finished touring for its unsuccessful previous album Caress of Steel, in early 1976.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Led Zeppelin (Led Zeppelin II)",
                        Description = "Led Zeppelin II is the second studio album by the English rock band Led Zeppelin, released on 22 October 1969 in the United States and on 31 October 1969 in the United Kingdom by Atlantic Records.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Uriah Heep (Look at Yourself)",
                        Description = "Look at Yourself is the third studio album by British rock band Uriah Heep, released in September 1971 by Bronze Records in the UK and Mercury Records in the US.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Kansas (Leftoverture)",
                        Description = "Leftoverture is the fourth studio album by American rock band Kansas, released in 1976. The album was reissued in remastered format on CD in 2001. It was the band's first album to be certified by the RIAA, and remains their highest selling album, having been certified 5 times platinum in the United States.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Marillion (Misplaced Childhood)",
                        Description = "Misplaced Childhood is the third studio album by the British neo-progressive rock band Marillion, released in 1985. It is a concept album loosely based on the childhood of Marillion's lead singer, Fish, who was inspired by a brief incident that occurred while he was under the influence of LSD.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Pink Floyd (The Wall)",
                        Description = "The Wall is the eleventh studio album by the English progressive rock band Pink Floyd, released on 30 November 1979 by Harvest/EMI and Columbia/CBS Records. It is a rock opera that explores Pink, a jaded rock star whose eventual self-imposed isolation from society forms a figurative wall.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Dream Theater (The Astonishing)",
                        Description = "The Astonishing is the thirteenth studio album by American progressive metal band Dream Theater, released on January 29, 2016 through Roadrunner Records. It is the band's second concept album, with a story conceived by guitarist John Petrucci and music written by Petrucci and keyboardist Jordan Rudess.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Chroma Key (Dead Air for Radios)",
                        Description = "Dead Air for Radios studio album by Kevin Moore, under the musical moniker Chroma Key. It was released through Fight Evil Records on December 16, 1998. The album was recorded by Steve Tushar at Bill's Place Rehearsal Studio in Hollywood, mixed by both Steve Tushar and Kevin Moore with final mastering by Eddy Schreyer.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    // user/jazz
                    new Product()
                    {
                        Name = "Miles Davis (Kind of Blue)",
                        Description = "Kind of Blue is a studio album by American jazz trumpeter, composer, and bandleader Miles Davis. It was recorded on March 2 and April 22, 1959, at Columbia's 30th Street Studio in New York City, and released on August 17 of that year by Columbia Records. ",
                        CategoryId = 2,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Miles Davis (In a Silent Way)",
                        Description = "In a Silent Way is a studio album by American jazz trumpeter, composer, and bandleader Miles Davis, released on July 30, 1969, on Columbia Records. Produced by Teo Macero, the album was recorded in one session date on February 18, 1969, at CBS 30th Street Studio in New York City. ",
                        CategoryId = 2,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    // user/blues
                    new Product()
                    {
                        Name = "Joe Bonamassa (Blues Deluxe)",
                        Description = "Blues Deluxe is the third studio album by American blues-rock musician Joe Bonamassa. Recorded at Unique Recording Studios in New York City, New York, it was produced by Bob Held and features nine cover versions of songs by classic blues artists and three original tracks.",
                        CategoryId = 3,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    new Product()
                    {
                        Name = "Joe Bonamassa (Redemption)",
                        Description = "Redemption is the thirteenth studio album by American blues rock guitarist Joe Bonamassa. It was released on September 21, 2018 through Provogue / Mascot Music Productions. ",
                        CategoryId = 3,
                        Price = 49,
                        ApplicationUserId = 2,
                    },
                    // user2/rock
                    new Product()
                    {
                        Name = "Transatlantic (The Whirlwind)",
                        Description = "The Whirlwind is the third studio album by the band Transatlantic, released on October 23, 2009. It is available in three formats: a standard edition, a double disc special edition and a deluxe edition with a 105-minute making-of DVD. The main album, while indexed into twelve tracks, is considered one song.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                    new Product()
                    {
                        Name = "Spock's Beard (Snow)",
                        Description = "Snow is the sixth studio album of the progressive rock band Spock's Beard, and the final album with main songwriter and vocalist Neal Morse, who left immediately after the release of the album due to his conversion to Christianity. It was released in 2002 on Radiant Records.",
                        CategoryId = 1,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                    // user2/jazz
                    new Product()
                    {
                        Name = "Bill Evans Trio (Waltz for Debby)",
                        Description = "Waltz for Debby is a live album by jazz pianist and composer Bill Evans and his trio consisting of Evans, bassist Scott LaFaro, and drummer Paul Motian. It was released in 1962.",
                        CategoryId = 2,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                    new Product()
                    {
                        Name = "John Coltrane (Coltrane)",
                        Description = "Coltrane is a studio album by jazz saxophonist, bandleader, and composer John Coltrane. It was recorded in April and June 1962, and released in July of that same year by Impulse! Records.",
                        CategoryId = 2,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                    // user2/blues
                    new Product()
                    {
                        Name = "John Lee Hooker (Waltz for Debby)",
                        Description = "Chill Out is a 1995 album by John Lee Hooker featuring Van Morrison, Carlos Santana, Charles Brown, and Booker T. Jones. It was produced by Roy Rogers, Santana and Hooker himself, and executive produced by Mike Kappus.",
                        CategoryId = 3,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                    new Product()
                    {
                        Name = "B.B. King (Lucille)",
                        Description = "Lucille is the fifteenth album by blues artist B. B. King. It is named for his famous succession of Gibson guitars, currently the Signature ES-355.",
                        CategoryId = 3,
                        Price = 49,
                        ApplicationUserId = 3,
                    },
                };
            return product;
        }
    }
}
