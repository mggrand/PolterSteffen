using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PolterSteffen
{
    public class Aufgabe_1
    {

        // ########################################### AUFGABE ####################################################################
        /// <summary>        /// 
        /// Schreibe eine Funktion, die eine Reihe von Zeichenketten annimmt und die eindeutige Folge von Ab�rzungen zur�ckgibt.
        ///        Die Funktion soll prim�r die L�nge der Abk�rzungen ausgeben, sekund�r die Ab�rzungen als Array.
        ///
        ///        Wie viele Buchstaben sind mindestens n�tig um die Zeichenfolgen eindeutig identifizieren zu k�nnen?
        ///
        ///        Beispiel 1:
        ///Eingabe: ["Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag"]
        ///        Ausgabe: 2, ["Mo", "Di", "Mi", "Do", "Fr", "Sa", "So"]
        ///
        ///
        ///        Beispiel 2:
        ///Eingabe: ["Januar", "Februar", "M�rz", "April", "Mai", "Juni", "Juli", "August", "September", "November", "Oktober", "November", "Dezember"]
        ///        Ausgabe: 3, ["Jan", "Feb", "M�r", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov" "Dez"]
        ///
        ///
        ///        Beispiel 3:
        ///Eingabe: ["Steffen", "Stefan", "Steven", "Stefanie", "Max", "Maximilian", "Hugo"]
        ///        Ausgabe: Keine Eindeutige Identifizierung m�glich
        ///
        /// </summary>
        /// <param name="lst">Liste von W�rtern</param>
        /// <returns>ein <see cref="Resultat"/> mit der Minimalen Zeichenl�ge und den Werten</returns>
        /// <exception cref="Exception">Wenn keine Minimale L�nge ermittelt werden kann.</exception>
        public Resultat SuchAbk�rzung(IEnumerable<string> lst)
        {
            // TODO Implementieren
            for (var i = 1; i <= lst.Min(x => x.Length); i++)
            {
                var abv = lst.Select(x => x[..i]).ToList();
                if (new HashSet<string>(abv).Count == lst.Count())
                {
                    return new Resultat(i, abv);

                }
            }
            throw new Exception("Keine Eindeutige Identifizierung m�glich");
        }


        public class Resultat
        {
            public Resultat(int zeichenMindestens, IList<string> zeichen)
            {
                ZeichenMindestens = zeichenMindestens;
                Zeichen = zeichen;
            }
            public int ZeichenMindestens { get; set; }
            public IList<string> Zeichen { get; }
        }

        // ###############################################################################################################



        // ########################################### TESTS ####################################################################

        [Fact]
        public void Wochentage()
        {
            var wochenTage = new string[] { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag", "Sonntag" };

            var resultat = SuchAbk�rzung(wochenTage);

            Assert.Equal(2, resultat.ZeichenMindestens);
            Assert.Collection(resultat.Zeichen,
                w => w.Equals("Mo"),
                w => w.Equals("Di"),
                w => w.Equals("Mi"),
                w => w.Equals("Do"),
                w => w.Equals("Fr"),
                w => w.Equals("Sa"),
                w => w.Equals("So"));
        }

        [Fact]
        public void Monate()
        {
            var monate = new string[] { "Januar", "Februar", "M�rz", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember" };

            var resultat = SuchAbk�rzung(monate);

            Assert.Equal(3, resultat.ZeichenMindestens);
            Assert.Collection(resultat.Zeichen,
                w => w.Equals("Jan"),
                w => w.Equals("Feb"),
                w => w.Equals("M�r"),
                w => w.Equals("Apr"),
                w => w.Equals("Mai"),
                w => w.Equals("Jun"),
                w => w.Equals("Jul"),
                w => w.Equals("Aug"),
                w => w.Equals("Sep"),
                w => w.Equals("Okt"),
                w => w.Equals("Noc"),
                w => w.Equals("Dez"));
        }

        [Fact]
        public void NichtM�glich()
        {
            var namen = new string[] { "Steffen", "Stefan", "Steven", "Stefanie", "Max", "Maximilian", "Hugo" };

            Action action = () => SuchAbk�rzung(namen);

            var excpetion = Assert.Throws<Exception>(action);
            Assert.Equal("Keine Eindeutige Identifizierung m�glich", excpetion.Message);

        }
    }
}