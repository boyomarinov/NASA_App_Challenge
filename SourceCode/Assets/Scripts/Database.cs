using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Database
{

    public static Dictionary<Buildings, string[]> buildings = new Dictionary<Buildings, string[]>();
    public static Dictionary<Units, string[]> devices = new Dictionary<Units, string[]>();
    public static Dictionary<ResourcesColony, string[]> resources = new Dictionary<ResourcesColony, string[]>();

    public static void FillData()
    {
        buildings.Add(Buildings.CommandCenter, new string[]
		{
			"Colony Control Center",
			@"Colony Control Center (CCC) is the main building in our moon colony, built from  initial materials brought from the Earth. It provides the necessary equipment to communicate with Earth and with all the units within the colony. Every command from the Earth is send to the CCC where all the information is being proceeded and analyzed. The database with information about all resources in the colony, built devices and buildings is stored in the Control Center and when a new building or device has to be build, CCC searches for available units that can be used in the process.

CCC also has a landing platform with infrastructure allowing easy deploying of materials brought from Earth.  

Only one Control Center is allowed in a colony.
"
		});

        buildings.Add(Buildings.UnitsFactory, new string[]
		{
			"Unit Factory",
			@"The Unit Factory (UF) is responsible for building new parts and assembling devices essential for the colony expansion. You are allowed to configure a set of initial devices that will be used in the Unit Factory. 

The Unit Factory have an important role in the colony and you will need more than one to ensure the growth of your industry. Every UF should be used to do specific tasks.

3D printers, Robotic arms and many other devices will be available in the UF.
"
		});

        buildings.Add(Buildings.Refinery, new string[]
		{
			"Refinery",
			@"A Refinery is a production facility composed of a group of chemical engineering unit processes and unit operations refining certain materials or converting raw material into products of value.

The main raw material that the moon refinery uses is the regolith which is delivered from the regolith mine. 

The refinery is a crucial part of the moon colony and is the heart of production process.
"
		});
        buildings.Add(Buildings.Mine, new string[]
		{
			"Mine",
			@"Mine info.
"
		});
        buildings.Add(Buildings.PowerPlant, new string[]
		{
			"Power Plant",
			@"Power plant info.
"
		});
        buildings.Add(Buildings.Silo, new string[]
		{
			"Silo",
			@"Power plant info.
"
		});
        buildings.Add(Buildings.Hangar, new string[]
		{
			"Hangar",
			@"Power plant info.
"
		});
        resources.Add(ResourcesColony.Iron, new string[]
  {
   "Iron",
   @"Iron metal has been used since ancient times, though copper alloys, which have lower melting temperatures, were used first in history. Pure iron is soft (softer than aluminium), but is unobtainable by smelting. The material is significantly hardened and strengthened by impurities from the smelting process, such as carbon. A certain proportion of carbon (between 0.002% and 2.1%) produces steel, which may be up to 1000 times harder than pure iron.",
   @"http://en.wikipedia.org/wiki/Iron"
  });

        resources.Add(ResourcesColony.Water, new string[]
  {
   "Water Ice",
   @"The moon water ice is relatively pure, the researchers found. High concentration of water ice at the bottom of Cabeus. Future moon-dwellers could conceivably mine such large quantities of ice efficiently. They could it process it into its constituent hydrogen and oxygen, prime ingredients of rocket fuel. And they could melt the ice down and drink it.",
   @"http://www.space.com/9374-moon-crater-water-parts-earth.html"
  });

        resources.Add(ResourcesColony.Helium_3, new string[]
  {
   "Helium 3",
   @"The fuel source of the future. The moon is said to have an abundance of Helium 3, in fact somewhere around 1,100,000 metric tonnes.  In retrospect it will take only an estimated 100 tonnes to power the earth for a year.  The Chinese plan to land on the moon in 2017 to do research on the moon and to look for Helium 3",
   @"http://www.freewebs.com/helium3/"
  });

        resources.Add(ResourcesColony.Carbon_Monoxide, new string[]
  {
   "Carbon Monoxide",
   @"Carbon monoxide (CO) is a colorless, odorless, and tasteless gas that is slightly lighter than air. It is toxic to humans and animals when encountered in higher concentrations, although it is also produced in normal animal metabolism in low quantities, and is thought to have some normal biological functions. In the atmosphere it is spatially variable, short lived, having a role in the formation of ground-level ozone.",
   @"http://en.wikipedia.org/wiki/Carbon_monoxide#Uses"
  });

        resources.Add(ResourcesColony.Ammonia, new string[]
  {
   "Ammonia",
   @"Ammonia or azane is a compound of nitrogen and hydrogen with the formula NH3. It is a colourless gas with a characteristic pungent smell. Ammonia contributes significantly to the nutritional needs of terrestrial organisms by serving as a precursor to food and fertilizers. Ammonia, either directly or indirectly, is also a building-block for the synthesis of many pharmaceuticals and is used in many commercial cleaning products. Although in wide use, ammonia is both caustic and hazardous.",
   @"http://en.wikipedia.org/wiki/Ammonia#Uses"
  });

        resources.Add(ResourcesColony.Methane, new string[]
  {
   "Methane",
   @"Methane (pronounced /ˈmɛθeɪn/ or /ˈmiːθeɪn/) is a chemical compound with the chemical formula CH4. It is the simplest alkane, the main component of natural gas, and probably[citation needed] the most abundant organic compound on earth. The relative abundance of methane makes it an attractive fuel. However, because it is a gas at normal conditions, methane is difficult to transport from its source",
   @"http://en.wikipedia.org/wiki/Methane#Uses"
  });

        resources.Add(ResourcesColony.Mercury, new string[]
  {
   "Mercury",
   @"Mercury is a chemical element with the symbol Hg and atomic number 80. It is commonly known as quicksilver and was formerly named hydrargyrum (from Greek ""hydr-"" water and ""argyros"" silver). A heavy, silvery d-block element, mercury is the only metal that is liquid at standard conditions for temperature and pressure; the only other element that is liquid under these conditions is bromine, though metals such as caesium, gallium, and rubidium melt just above room temperature.",
   @"http://en.wikipedia.org/wiki/Mercury_%28element%29#Applications"
  });

        resources.Add(ResourcesColony.Gold, new string[]
  {
   "Gold",
   @"Besides its widespread monetary and symbolic functions, gold has many practical uses in dentistry, electronics, and other fields. Its high malleability, ductility, resistance to corrosion and most other chemical reactions, and conductivity of electricity has led to many uses, including electric wiring, colored-glass production, and gold leafing.",
   @"http://en.wikipedia.org/wiki/Gold"
  });

        resources.Add(ResourcesColony.Platinum, new string[]
  {
   "Platinum",
   @"Platinum is used in catalytic converters, laboratory equipment, electrical contacts and electrodes, platinum resistance thermometers, dentistry equipment, and jewelry. Because only a few hundred tonnes are produced annually, it is a scarce material, and is highly valuable and is a major precious metal commodity. Being a heavy metal, it leads to health issues upon exposure to its salts, but due to its corrosion resistance, it is not as toxic as some metals.",
   @"http://en.wikipedia.org/wiki/Platinum"
  });

        resources.Add(ResourcesColony.Silicon, new string[]
  {
   "Silicon",
   @"Elemental silicon also has a large impact on the modern world economy. Although most free silicon is used in the steel refining, aluminum-casting, and fine chemical industries (often to make fumed silica), the relatively small portion of very highly purified silicon that is used in semiconductor electronics (< 10%) is perhaps even more critical. Because of wide use of silicon in integrated circuits, the basis of most computers, a great deal of modern technology depends on it.",
   @"http://en.wikipedia.org/wiki/Silicon"
  });
        resources.Add(ResourcesColony.Silica, new string[]
  {
   "Silicon dioxide",
   @"Silicon dioxide, also known as silica (from the Latin silex), is a chemical compound that is an oxide of silicon with the chemical formula SiO2. It has been known since ancient times. Silica is most commonly found in nature as sand or quartz, as well as in the cell walls of diatoms.",
   @"http://en.wikipedia.org/wiki/Silicon_dioxide"
  }); resources.Add(ResourcesColony.Aluminium, new string[]
  {
   "Aluminium oxide",
   @"Aluminium oxide is a chemical compound of aluminium and oxygen with the chemical formula Al2O3. It is the most commonly occurring of several aluminium oxides, and specifically identified as aluminium(III) oxide.",
   @"http://en.wikipedia.org/wiki/Aluminium_oxide"
  });

        // UNITS

        devices.Add(Units.Builder, new string[]
  {
   "Builder",
   @"Iron metal has been used since ancient times, though copper alloys, which have lower melting temperatures, were used first in history. Pure iron is soft (softer than aluminium), but is unobtainable by smelting. The material is significantly hardened and strengthened by impurities from the smelting process, such as carbon. A certain proportion of carbon (between 0.002% and 2.1%) produces steel, which may be up to 1000 times harder than pure iron."
  });

        devices.Add(Units.Bulldozer, new string[]
  {
   "Bulldozer",
   @"Iron metal has been used since ancient times, though copper alloys, which have lower melting temperatures, were used first in history. Pure iron is soft (softer than aluminium), but is unobtainable by smelting. The material is significantly hardened and strengthened by impurities from the smelting process, such as carbon. A certain proportion of carbon (between 0.002% and 2.1%) produces steel, which may be up to 1000 times harder than pure iron."
  });

        devices.Add(Units.Collector, new string[]
  {
   "Collector",
   @"Iron metal has been used since ancient times, though copper alloys, which have lower melting temperatures, were used first in history. Pure iron is soft (softer than aluminium), but is unobtainable by smelting. The material is significantly hardened and strengthened by impurities from the smelting process, such as carbon. A certain proportion of carbon (between 0.002% and 2.1%) produces steel, which may be up to 1000 times harder than pure iron."
  });
        devices.Add(Units.Miner, new string[]
  {
   "Miner",
   @"Iron metal has been used since ancient times, though copper alloys, which have lower melting temperatures, were used first in history. Pure iron is soft (softer than aluminium), but is unobtainable by smelting. The material is significantly hardened and strengthened by impurities from the smelting process, such as carbon. A certain proportion of carbon (between 0.002% and 2.1%) produces steel, which may be up to 1000 times harder than pure iron."
  });
    }


}
