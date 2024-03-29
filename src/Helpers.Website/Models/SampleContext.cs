﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers.Website.Models
{
    public static class SampleContext
    {
        public static IQueryable<Person> People
        {
            get
            {
                return PeopleSource().AsQueryable();
            }
        }

        public static List<Person> PeopleSource()
        {
            return new List<Person>
            {
                new Person(1,"Vira","Duran","sit.amet@necanteMaecenas.co.uk", new DateTime(1978,11,28),"Iceland", new PersonAddress { AddressLine1 = "First" },155987,"red"),
                new Person(2,"Daquan","Mcdowell","id.nunc@nuncullamcorpereu.co.uk", new DateTime(1985,01,08),"United States",new PersonAddress { AddressLine1 = "First" },165363, "green"),
                new Person(3,"Lysandra","Holloway","dui@Donec.edu", new DateTime(1986,04,11),"Bulgaria",new PersonAddress { AddressLine1 = "First" },192721, "red"),
                new Person(4,"Piper","Larsen","scelerisque@volutpatNullafacilisis.org", new DateTime(1968,04,14),"Lebanon",new PersonAddress { AddressLine1 = "First" },143123,"pink"),
                new Person(5,"Carissa","Mueller","Suspendisse.sagittis.Nullam@nislNulla.co.uk", new DateTime(1964,01,19),"Denmark", new PersonAddress { AddressLine1 = "First" },118871,"blue"),
                new Person(6,"Georgia","Henson","fames.ac@Cras.ca", new DateTime(1955,08,16),"Sint Maarten", new PersonAddress { AddressLine1 = "First" },155419,"red"),
                new Person(7,"Barry","Garrett","Nullam.ut.nisi@Cras.net", new DateTime(1995,05,28),"French Polynesia", new PersonAddress { AddressLine1 = "First" },115739,"blue"),
                new Person(8,"Jordan","Johnston","Etiam.gravida@Vestibulumuteros.ca", new DateTime(1950,10,06),"Malta", new PersonAddress { AddressLine1 = "First" },163069,"black"),
                new Person(9,"Sonya","Hubbard","ut.nulla.Cras@consectetueradipiscingelit.com", new DateTime(1984,08,09),"South Sudan", new PersonAddress { AddressLine1 = "First" },187759,"orange"),
                new Person(10,"Ezekiel","Randolph","et.magnis.dis@Donec.edu", new DateTime(1955,09,05),"Saint Helena", new PersonAddress { AddressLine1 = "First" },105221,"red"),
                new Person(11,"Herrod","Jordan","non.egestas.a@pede.net", new DateTime(1964,11,05),"Vanuatu",new PersonAddress { AddressLine1 = "First" },173401, "pink"),
                new Person(12,"Colorado","Espinoza","egestas.ligula@risus.edu", new DateTime(1947,06,27),"Micronesia", new PersonAddress { AddressLine1 = "First" },115114,"blue"),
                new Person(13,"Maryam","Galloway","purus.in@vestibulumneceuismod.org", new DateTime(1947,05,30),"Jersey", new PersonAddress { AddressLine1 = "First" },121975,"pink"),
                new Person(14,"Ulla","Austin","porttitor@commodo.ca", new DateTime(1948,12,08),"United Arab Emirates", new PersonAddress { AddressLine1 = "First" },123682,"red"),
                new Person(15,"Maisie","Wilkins","sagittis.lobortis@elementumdui.ca", new DateTime(1963,08,20),"South Sudan", new PersonAddress { AddressLine1 = "First" },113109,"orange"),
                new Person(16,"Hanna","Alvarez","Aenean@estvitae.co.uk", new DateTime(1955,12,17),"Bolivia", new PersonAddress { AddressLine1 = "First" },125137,"black"),
                new Person(17,"Melanie","Pittman","fermentum.risus.at@amalesuadaid.co.uk", new DateTime(1981,06,11),"Angola", new PersonAddress { AddressLine1 = "First" },153462,"yellow"),
                new Person(18,"Tanya","Moran","eu@lectusante.org", new DateTime(1968,10,03),"Saint Pierre and Miquelon", new PersonAddress { AddressLine1 = "First" },106660,"yellow"),
                new Person(19,"Maisie","Christensen","inceptos.hymenaeos.Mauris@orci.edu", new DateTime(1985,10,31),"Bolivia", new PersonAddress { AddressLine1 = "First" },149066,"orange"),
                new Person(20,"Gareth","Shepard","arcu.Vestibulum.ante@dolortempus.co.uk", new DateTime(1978,03,03),"Saint Lucia", new PersonAddress { AddressLine1 = "First" },170388,"pink"),
                new Person(21,"Driscoll","Houston","mus.Aenean.eget@Cras.net", new DateTime(1958,10,10),"Cambodia", new PersonAddress { AddressLine1 = "First" },125625,"black"),
                new Person(22,"Maisie","Warner","pellentesque.a.facilisis@rutrum.com", new DateTime(1952,04,10),"Brunei", new PersonAddress { AddressLine1 = "First" },101466,"green"),
                new Person(23,"Rhona","Patel","dictum@tristique.edu", new DateTime(1979,07,21),"Indonesia",new PersonAddress { AddressLine1 = "First" },179807, "red"),
                new Person(24,"Donovan","Sheppard","ipsum.sodales.purus@eu.edu", new DateTime(1962,07,24),"Norfolk Island", new PersonAddress { AddressLine1 = "First" },174728,"black"),
                new Person(25,"Connor","Underwood","aliquet.odio@ullamcorperDuiscursus.ca", new DateTime(1986,01,04),"Mozambique", new PersonAddress { AddressLine1 = "First" },149540,"pink"),
                new Person(26,"Wanda","Duncan","imperdiet@tinciduntcongueturpis.co.uk", new DateTime(1958,06,01),"France", new PersonAddress { AddressLine1 = "First" },134290,"pink"),
                new Person(27,"Morgan","Obrien","enim.nec.tempus@utpharetra.com", new DateTime(1956,06,14),"Thailand", new PersonAddress { AddressLine1 = "First" },145642,"green"),
                new Person(28,"Keiko","Vasquez","odio.a@odioEtiamligula.co.uk", new DateTime(1995,07,12),"South Africa", new PersonAddress { AddressLine1 = "First" },102547,"blue"),
                new Person(29,"Benjamin","Anderson","Mauris.nulla@mifelis.com", new DateTime(1960,10,01),"Sudan", new PersonAddress { AddressLine1 = "First" },125023,"pink"),
                new Person(30,"Jin","Savage","semper.auctor@malesuadaIntegerid.ca", new DateTime(1991,09,29),"Poland", new PersonAddress { AddressLine1 = "First" },180570,"yellow"),
                new Person(31,"Mollie","Lawson","magnis.dis.parturient@Loremipsum.net", new DateTime(1947,08,19),"Norfolk Island", new PersonAddress { AddressLine1 = "First" },178244,"pink"),
                new Person(32,"Yvonne","Flores","luctus.aliquet@dignissimlacusAliquam.org", new DateTime(1963,04,04),"Libya", new PersonAddress { AddressLine1 = "First" },113131,"green"),
                new Person(33,"Rhiannon","Lindsay","ac.risus@ligula.ca", new DateTime(1985,09,06),"Ecuador", new PersonAddress { AddressLine1 = "First" },150118,"blue"),
                new Person(34,"Iris","Gonzalez","leo.in@elitAliquamauctor.co.uk", new DateTime(1973,04,19),"Burkina Faso", new PersonAddress { AddressLine1 = "First" },154244,"orange"),
                new Person(35,"Fletcher","Velez","vel@anteMaecenas.ca", new DateTime(1970,02,23),"Wallis and Futuna", new PersonAddress { AddressLine1 = "First" },185080,"red"),
                new Person(36,"Carl","Summers","faucibus@cubiliaCuraePhasellus.co.uk", new DateTime(1972,09,14),"South Africa", new PersonAddress { AddressLine1 = "First" },157274,"violet"),
                new Person(37,"Urielle","Mccoy","pede.nec@Curabituregestasnunc.co.uk", new DateTime(1979,01,17),"Uganda", new PersonAddress { AddressLine1 = "First" },128994,"yellow"),
                new Person(38,"Kylee","Carney","Cras.dolor@indolor.net", new DateTime(1966,05,21),"Denmark", new PersonAddress { AddressLine1 = "First" },188910,"black"),
                new Person(39,"Jasper","Suarez","erat@massaQuisque.net", new DateTime(1991,11,12),"Israel", new PersonAddress { AddressLine1 = "First" },172619,"green"),
                new Person(40,"Joan","Harrell","lorem.auctor@acmattis.co.uk", new DateTime(1964,07,09),"Marshall Islands", new PersonAddress { AddressLine1 = "First" },192380,"orange"),
                new Person(41,"Gannon","Valenzuela","interdum.Curabitur.dictum@necmauris.com", new DateTime(1958,04,07),"Togo", new PersonAddress { AddressLine1 = "First" },107791,"brown"),
                new Person(42,"Naomi","Moses","ac@netus.co.uk", new DateTime(1984,01,22),"Cameroon", new PersonAddress { AddressLine1 = "First" },131158,"red"),
                new Person(43,"Tatiana","Kemp","massa@Nunc.net", new DateTime(1961,01,09),"Ghana", new PersonAddress { AddressLine1 = "First" },121620,"brown"),
                new Person(44,"Bree","Gonzales","Cum.sociis.natoque@aarcu.ca", new DateTime(1994,11,09),"Liechtenstein", new PersonAddress { AddressLine1 = "First" },184545,"blue"),
                new Person(45,"Ulric","Bates","nec.urna.et@interdumliberodui.org", new DateTime(1995,06,07),"Faroe Islands", new PersonAddress { AddressLine1 = "First" },144283,"orange"),
                new Person(46,"Isaiah","Albert","semper.auctor.Mauris@Phasellusvitae.com", new DateTime(1950,09,08),"El Salvador", new PersonAddress { AddressLine1 = "First" },123419,"black"),
                new Person(47,"Jeanette","Leach","sed.leo@et.com", new DateTime(1955,10,30),"Egypt", new PersonAddress { AddressLine1 = "First" },114093,"pink"),
                new Person(48,"Gretchen","Miranda","eros.turpis.non@duiaugueeu.org", new DateTime(1957,03,31),"Paraguay", new PersonAddress { AddressLine1 = "First" },160896,"green"),
                new Person(49,"Jorden","Oneal","erat.semper@atvelitCras.co.uk", new DateTime(1947,09,06),"Peru", new PersonAddress { AddressLine1 = "First" },166093,"orange"),
                new Person(50,"Kieran","Kirby","Donec.porttitor.tellus@Fuscemilorem.edu", new DateTime(1963,09,29),"Tonga", new PersonAddress { AddressLine1 = "First" },151899,"violet"),
                new Person(51,"Nell","Barlow","ante.Maecenas.mi@faucibus.net", new DateTime(1970,09,01),"Sweden", new PersonAddress { AddressLine1 = "First" },150291,"red"),
                new Person(52,"Jade","Rich","quis.arcu@dignissimMaecenasornare.com", new DateTime(1978,09,15),"Slovenia", new PersonAddress { AddressLine1 = "First" },193336,"green"),
                new Person(53,"Abdul","Riddle","enim.condimentum.eget@fermentum.net", new DateTime(1963,05,18),"Guadeloupe", new PersonAddress { AddressLine1 = "First" },121746,"black"),
                new Person(54,"Chandler","Pruitt","in@fringilla.edu", new DateTime(1953,09,28),"Philippines", new PersonAddress { AddressLine1 = "First" },144102,"pink"),
                new Person(55,"Emerald","Myers","lacus.varius.et@elementum.ca", new DateTime(1952,11,27),"Israel", new PersonAddress { AddressLine1 = "First" },100837,"orange"),
                new Person(56,"Bradley","Chambers","est.Nunc@egetvenenatisa.com", new DateTime(1956,12,31),"Croatia", new PersonAddress { AddressLine1 = "First" },156709,"pink"),
                new Person(57,"Clio","Anderson","iaculis.odio.Nam@Sed.org", new DateTime(1990,11,28),"Trinidad and Tobago", new PersonAddress { AddressLine1 = "First" },138720,"yellow"),
                new Person(58,"Cynthia","Boyer","per.inceptos.hymenaeos@malesuada.org", new DateTime(1979,03,06),"Saint Kitts and Nevis", new PersonAddress { AddressLine1 = "First" },151197,"pink"),
                new Person(59,"Oscar","Henry","Sed@euligulaAenean.org", new DateTime(1987,02,15),"Burundi", new PersonAddress { AddressLine1 = "First" },164162,"yellow"),
                new Person(60,"Chelsea","Watts","ac@Proin.co.uk", new DateTime(1965,12,26),"Jamaica", new PersonAddress { AddressLine1 = "First" },115803,"violet"),
                new Person(61,"Rigel","Elliott","sagittis@ipsumnuncid.co.uk", new DateTime(1987,09,23),"Moldova", new PersonAddress { AddressLine1 = "First" },143653,"pink"),
                new Person(62,"Jonah","Kemp","mattis.ornare.lectus@magnaSuspendisse.co.uk", new DateTime(1966,01,07),"Swaziland", new PersonAddress { AddressLine1 = "First" },116502,"yellow"),
                new Person(63,"Ulla","Haley","et.euismod.et@augueid.co.uk", new DateTime(1992,09,02),"Chad", new PersonAddress { AddressLine1 = "First" },182221,"violet"),
                new Person(64,"Maxine","Hobbs","tellus.non.magna@egestas.co.uk", new DateTime(1978,11,19),"Central African Republic", new PersonAddress { AddressLine1 = "First" },130496,"black"),
                new Person(65,"Desirae","Ellison","ullamcorper.velit.in@risus.ca", new DateTime(1965,06,13),"Colombia",new PersonAddress { AddressLine1 = "First" },148765, "orange"),
                new Person(66,"Alana","Hill","sed@mattisCraseget.net", new DateTime(1949,06,07),"Thailand", new PersonAddress { AddressLine1 = "First" },134462,"blue"),
                new Person(67,"Cassandra","Mcdaniel","Morbi.vehicula@Quisqueornaretortor.co.uk", new DateTime(1952,11,12),"Denmark", new PersonAddress { AddressLine1 = "First" },124712,"red"),
                new Person(68,"Amena","Simon","nibh.enim@NullafacilisiSed.ca", new DateTime(1962,03,03),"Guam", new PersonAddress { AddressLine1 = "First" },130465,"blue"),
                new Person(69,"Evelyn","Daniels","aliquet@Sedmolestie.com", new DateTime(1993,08,14),"Comoros", new PersonAddress { AddressLine1 = "First" },148738,"orange"),
                new Person(70,"Venus","Parrish","ante.iaculis.nec@consequat.org", new DateTime(1948,07,22),"Sri Lanka", new PersonAddress { AddressLine1 = "First" },150123,"yellow"),
                new Person(71,"Ryan","Frost","quis@tincidunt.ca", new DateTime(1959,03,05),"Uganda", new PersonAddress { AddressLine1 = "First" },177784,"black"),
                new Person(72,"Hilel","Ballard","dapibus@semper.com", new DateTime(1949,03,25),"Guinea", new PersonAddress { AddressLine1 = "First" },134271,"violet"),
                new Person(73,"Ferris","Kidd","sem@sodalespurus.ca", new DateTime(1970,08,05),"Malawi", new PersonAddress { AddressLine1 = "First" },154756,"blue"),
                new Person(74,"Judith","Shaffer","pede@ipsum.ca", new DateTime(1992,09,30),"Dominican Republic", new PersonAddress { AddressLine1 = "First" },156177,"red"),
                new Person(75,"Wylie","Cotton","quis.arcu.vel@ipsum.net", new DateTime(1948,03,06),"Saint Helena, Ascension and Tristan da Cunha", new PersonAddress { AddressLine1 = "First" },185095,"brown"),
                new Person(76,"Eden","Lawrence","lacus.Quisque@odio.org", new DateTime(1972,01,11),"Cambodia", new PersonAddress { AddressLine1 = "First" },155908,"violet"),
                new Person(77,"Amethyst","Nieves","pharetra.Quisque.ac@vehicularisus.com", new DateTime(1972,04,15),"Martinique", new PersonAddress { AddressLine1 = "First" },197725,"black"),
                new Person(78,"Alyssa","Cleveland","ante.ipsum.primis@estvitaesodales.ca", new DateTime(1964,03,28),"China", new PersonAddress { AddressLine1 = "First" },125543,"red"),
                new Person(79,"Riley","Mcgowan","habitant.morbi.tristique@tempus.co.uk", new DateTime(1950,12,18),"Slovenia", new PersonAddress { AddressLine1 = "First" },138434,"red"),
                new Person(80,"Jessica","Mills","lobortis.nisi@eratnonummyultricies.ca", new DateTime(1961,12,28),"Guyana", new PersonAddress { AddressLine1 = "First" },189344,"black"),
                new Person(81,"Iola","Roy","blandit.at.nisi@dictumProin.com", new DateTime(1971,06,18),"Micronesia", new PersonAddress { AddressLine1 = "First" },129133,"black"),
                new Person(82,"Rahim","Kinney","velit@mieleifendegestas.edu", new DateTime(1989,01,21),"Russian Federation", new PersonAddress { AddressLine1 = "First" },124862,"blue"),
                new Person(83,"Molly","Maddox","faucibus.orci.luctus@malesuadamalesuada.org", new DateTime(1950,02,17),"Honduras", new PersonAddress { AddressLine1 = "First" },146805,"pink"),
                new Person(84,"Ima","Battle","elit@tortordictumeu.org", new DateTime(1981,12,18),"Mexico", new PersonAddress { AddressLine1 = "First" },151563,"black"),
                new Person(85,"Acton","Case","Donec@lectuspede.ca", new DateTime(1970,08,11),"Puerto Rico", new PersonAddress { AddressLine1 = "First" },151714,"violet"),
                new Person(86,"India","Mueller","molestie.dapibus.ligula@Fusce.co.uk", new DateTime(1965,08,11),"Seychelles", new PersonAddress { AddressLine1 = "First" },105870,"orange"),
                new Person(87,"Damon","Goodwin","vulputate.nisi.sem@rutrumloremac.ca", new DateTime(1996,12,16),"Eritrea", new PersonAddress { AddressLine1 = "First" },106710,"blue"),
                new Person(88,"Allegra","Moody","mi.pede.nonummy@infaucibusorci.org", new DateTime(1992,06,29),"Pakistan", new PersonAddress { AddressLine1 = "First" },194579,"yellow"),
                new Person(89,"Fuller","Ball","amet.ante@nibhPhasellusnulla.ca", new DateTime(1970,04,16),"Svalbard and Jan Mayen Islands",new PersonAddress { AddressLine1 = "First" },187090, "blue"),
                new Person(90,"Ruth","Perry","Nunc.mauris.elit@elitNulla.net", new DateTime(1977,12,30),"Finland", new PersonAddress { AddressLine1 = "First" },198152,"red"),
                new Person(91,"Willa","Madden","risus.quis.diam@fames.org", new DateTime(1970,09,08),"Turkmenistan", new PersonAddress { AddressLine1 = "First" },179938,"orange"),
                new Person(92,"Lee","Benson","enim.gravida.sit@quisaccumsan.ca", new DateTime(1992,07,16),"Åland Islands", new PersonAddress { AddressLine1 = "First" },133560,"green"),
                new Person(93,"Imogene","Knowles","ut.nulla.Cras@arcu.org", new DateTime(1987,01,22),"Isle of Man", new PersonAddress { AddressLine1 = "First" },192589,"brown"),
                new Person(94,"Dominique","Mcmillan","nunc.nulla@lacus.edu", new DateTime(1997,06,10),"Niger", new PersonAddress { AddressLine1 = "First" },169879,"black"),
                new Person(95,"Kellie","Gill","Praesent.luctus@ipsumdolorsit.edu", new DateTime(1994,11,26),"Saint Kitts and Nevis", new PersonAddress { AddressLine1 = "First" },162214,"violet"),
                new Person(96,"Jael","Bennett","ligula.Nullam.feugiat@vulputate.net", new DateTime(1967,12,27),"Samoa", new PersonAddress { AddressLine1 = "First" },145008,"orange"),
                new Person(97,"Arden","Glenn","eu.enim@necleoMorbi.com", new DateTime(1975,06,18),"Greece", new PersonAddress { AddressLine1 = "First" },158751,"blue"),
                new Person(98,"Alice","Levy","non@est.net", new DateTime(1966,12,04),"Qatar", new PersonAddress { AddressLine1 = "First" },146369,"red"),
                new Person(99,"Bert","Santos","augue.eu.tempor@dolor.ca", new DateTime(1995,09,09),"Paraguay", new PersonAddress { AddressLine1 = "First" },187783,"pink"),
                new Person(100,"Azalia","Stark","ultricies.dignissim@nibhPhasellusnulla.ca", new DateTime(1956,06,14),"Malaysia",new PersonAddress { AddressLine1 = "First" },120437,"pink"),
            };
        }
    }
}
