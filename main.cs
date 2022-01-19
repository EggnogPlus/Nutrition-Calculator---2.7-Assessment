//Oliver Barclay 14 May 2021
using System;
using System.IO;
namespace Nutrition_Calculator
{
    class Program
    {

        // the main starting point validates input and calls to ReadData
        public static void Main(string[] args)
        {   
            int recipeNumber;
            Console.WriteLine("If you have a recipe, please enter the amount of ingredients in said recipe. If not, and are only searching for one ingredient, please enter 1");
            string ingredientNumber = Console.ReadLine();

            bool recipeValidation = true;
            while (recipeValidation == true)
            {
            
        
                if (!int.TryParse(ingredientNumber, out recipeNumber)){
                    Console.WriteLine("This is not a recipe length. Please try again!");
                    ingredientNumber = Console.ReadLine();
                }else{
                    recipeValidation = false;
                }
            
            }//end while
            int sumIngredients = Convert.ToInt32(ingredientNumber);
        
            while (sumIngredients > 0)//repeat until there are no ingredients left
            {    
                Console.WriteLine("Please enter what you are looking for. Only enter 1 ingredient in this box");
                string inputSearch = Console.ReadLine();
                inputSearch = inputSearch.ToLower();

                
                //int NumberCheck;
                bool check = false;


                while(check == false){
                    //Console.WriteLine("Not correct. Try again!!");
                    //inputSearch = Console.ReadLine();
                    if(string.IsNullOrEmpty(inputSearch)) {
                        Console.WriteLine("Empty String, Try again!");
                        inputSearch = Console.ReadLine();
                        inputSearch = inputSearch.ToLower();
                        check = false;
                    }//end if 1
            
            /*if(!int.TryParse(inputSearch, out NumberCheck)) {
                    Console.WriteLine("This is not an input! Please try again");
                    inputSearch = Console.ReadLine();
                    check = false;
             }else{
                 inputSearch = Console.ReadLine();
                 check = true;
             }*/

                if ( inputSearch.Length > 1){//if less or equal to one input
              //(input being one letter) repeat question as code cant handle printing entirety of nutfile at once
                        if (inputSearch[0]>='a' && inputSearch[0]<='z'){

                            for (int i = 0; i < inputSearch.Length; i++){

                                if ( inputSearch[i]>='a' && inputSearch[i]<='z' || inputSearch[i]==' '){

                                    check = true;

                                } //end if

                                else{
                                    Console.WriteLine("This is not a valid input. Try again please :)");
                                    inputSearch = Console.ReadLine();


                                    inputSearch = inputSearch.ToLower();
                                    check = false;
                                } //end else
                            } //end for
                        } //end >1 check
                        else{
                            Console.WriteLine("This is not a valid input. Try again please :)");
                                inputSearch = Console.ReadLine();

                                
                                inputSearch = inputSearch.ToLower();
                                check = false;

                        } //end else
                    }else {
                        Console.WriteLine("What you are searching for is too broad. Try again please :)");
                        inputSearch = Console.ReadLine();
                        inputSearch = inputSearch.ToLower();
                        check = false;
                    }
            }//end while

            //this asks for serving size
            Console.WriteLine("Please enter your Serving size amount in Grams");
            string servingInput = Console.ReadLine();
            
            bool valid = false;
            int negativeCheck;
            while (valid == false){

                if (int.TryParse(servingInput, out negativeCheck)){
                    if(servingInput.Contains('-')){
                        Console.WriteLine("This is not a whole number. Please enter your amount of Grams in a whole number :>");
                        servingInput = Console.ReadLine();
                        valid = false;
                    }else{
                        valid = true;
                    }
                    
                }else{
                    Console.WriteLine("This is not a whole number. Please enter your amount of Grams in a whole number :>");
                    servingInput = Console.ReadLine();
                } //end else
            }
               


            //Program p = new Program();
            //Console.WriteLine("Hello World!");
            const string fileName= "Nutrientfile.txt";
            int nutrientServing = Convert.ToInt32(servingInput);
            ReadData(fileName, inputSearch, nutrientServing);
            
            sumIngredients = sumIngredients - 1;
            Console.WriteLine($"Search Completed for: {inputSearch} with {servingInput}g");
            Console.WriteLine($"You have {sumIngredients} ingredient/s left");
            Console.WriteLine(" ");
            

            }
            
            
            //checking if value returns 
            //Console.WriteLine($"you are looking for {inputSearch}")
            
            
            
            
        }//end main

        //reading data from a file
        //this method will recieve a fileName parameter (Nutrient.txt)
        //what do i do with it?
        //read information from the file line by line and store this info somehow\
        //need a string variable to store a line from the file
        //and a loop to go through each line in the file
        //a line from the file looks like this
        //01A10072	"Beer, low alcohol (less than 1% alcohol v/v)"	43	0.2	0	0	1.1	0	6
        //line.Split(" ")

        //this is what reads the file and splits it into arrays for the main to access and calculate
        public static void ReadData (string fileName, string inputSearch, int nutrientServing){
            System.IO.StreamReader reader = new System.IO.StreamReader(fileName);

            string Lines; //it has no default value
            string [] lineArray;
            int counter = 0;
            while ((Lines = reader.ReadLine()) != null){
                lineArray = Lines.Split('\t');
                Lines = Lines.ToLower();

                    //   int x = 0;
                if (Lines.Contains(inputSearch) && counter !=0) { //the array of ingredients!!!!!! or call a function that searches for your item!!
                    //   Nutrient[x] = reader.ReadLine();

                    //   Console.WriteLine(Nutrient[x]); //checks if the values are being saved
                    //   x+=1; x = x+1;
                    //   if (x >= arraySize) break;//these three lines print out the entirety of nutfile.txt (nutrientfile.txt for short)
                    //this is used to check that im still able to read the file
                    //Console.WriteLine($"{lineArray[0]}");

                    //funnel line array data into another section of code and then put that output into the original place of line array
                    //the code below takes the line arrays from the file of the stuff the user searches for and multiplies them by how many g the user wants
                    double dontuse1 = Convert.ToDouble(lineArray[2]);
                    double zenergyPortion = dontuse1/100 * nutrientServing;

                    double dontuse2 = Convert.ToDouble(lineArray[3]);
                    double zproteinPortion = dontuse2/100 * nutrientServing;

                    double dontuse3 = Convert.ToDouble(lineArray[4]);
                    double zfatTotalPortion = dontuse3/100 * nutrientServing;

                    double dontuse4 = Convert.ToDouble(lineArray[5]);
                    double zfatSaturatedPortion = dontuse4/100 * nutrientServing;

                    double dontuse5 = Convert.ToDouble(lineArray[6]);
                    double zcarbPortion = dontuse5/100 * nutrientServing;

                    double dontuse6 = Convert.ToDouble(lineArray[7]);
                    double zsugarPortion= dontuse6/100 * nutrientServing;

                    double dontuse7 = Convert.ToDouble(lineArray[8]);
                    double zsodiumPortion = dontuse7/100 * nutrientServing;
                    //Console.WriteLine(EnergyPortion);
                    
                    //this calculate the daily intake of energy of ingredient, also makes it to two decimal points
                    double zdailyIntake = zenergyPortion/8700 * 100;
                    string dailyIntake = string.Format("{0:##0.00}", zdailyIntake);

                    //makes my outputted variables to two dp 
                    string energyPortion = string.Format("{0:##0.00}", zenergyPortion);
                    string proteinPortion = string.Format("{0:##0.00}", zproteinPortion);
                    string fatTotalPortion = string.Format("{0:##0.00}", zfatTotalPortion);
                    string fatSaturatedPortion = string.Format("{0:##0.00}", zfatSaturatedPortion);
                    string carbPortion = string.Format("{0:##0.00}", zcarbPortion);
                    string sugarPortion = string.Format("{0:##0.00}", zsugarPortion);
                    string sodiumPortion = string.Format("{0:##0.00}", zsodiumPortion);
                    
                    //this is what is outputted onto the users screen
                    Console.WriteLine($"{lineArray[0]} - {lineArray[1].Replace("\"", "")} - Per {nutrientServing}(g)");
                    //assuming all values in nutfile.txt is in 100 g including liquids as stated in the assessment file UPDATE: fixed it now :)
                    Console.WriteLine($"Amount of Energy. Per {nutrientServing}g: {energyPortion}(kJ), Percentage of Daily Intake: %{dailyIntake}  Per 100g: {lineArray[2]}");
                    Console.WriteLine($"Amount of Protein. Per {nutrientServing}g: {proteinPortion}(g)  Per 100g: {lineArray[3]}");
                    Console.WriteLine($"Amount of Fat, total. Per {nutrientServing}g: {fatTotalPortion}(g)  Per 100g: {lineArray[4]}");
                    Console.WriteLine($"Amount of Fat, saturated. Per {nutrientServing}g: {fatSaturatedPortion}(g)  Per 100g: {lineArray[5]}");
                    Console.WriteLine($"Amount of Available Carbohydrate. Per {nutrientServing}g: {carbPortion}(g)  Per 100g: {lineArray[6]}");
                    Console.WriteLine($"Amount of Total Sugars. Per {nutrientServing}g: {sugarPortion}(g)  Per 100g: {lineArray[7]}");
                    //sodium in the file is in mg. so the calculations don't have to be different to the others as the original file is in mg. As my-
                    //calculations only convert it to teh amount of g/mg
                    Console.WriteLine($"Amount of Sodium. Per {nutrientServing}mg: {sodiumPortion}(mg)  Per 100mg: {lineArray[8]}");
                    //and different lines of info i split with my array, the last line is to make it neat between the searched items
                    Console.WriteLine("   ");
                }//end if
                counter++;
            }//endwhile

            //lines has value of NULL = end of file
        //attempt to read data from file
        //int HelpMeOutOfThisHell = 99999; //now this is evidence of my code,
            //cause of how stupid this solution is hehe, hey its still not technically a hard coded value ;)

            //int arraySize = HelpMeOutOfThisHell;
            //string [] Nutrient = new string[arraySize]; //this stores # of values for our nutrient.txt list UPDATED: not anymore 

            //StreamReader reader;
            reader=File.OpenText(fileName);

            
            
        
        
    
            reader.Close();
        }//end readata

        /*static void WriteData(string fileName, string LineInfo){
            System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName);
            writer.WriteLine(LineInfo);
            string [] arrayInfo = LineInfo.Split(" ");


            for(int i=0; i< arrayInfo.Length; i++){
                writer.WriteLine($"the index is arrayInfo[{i}]:");
                writer.WriteLine(arrayInfo[i]);
            }//end for

            writer.Close();

        }*/
       
    }//end program
}//end namespace
