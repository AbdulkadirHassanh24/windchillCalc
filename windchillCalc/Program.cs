namespace WindchillCalc                                                                                                            
{                                                                                                                                  
    class Program                                                                                                                  
    {                                                                                                                              
        static void Main(string[] args)                                                                                            
        {                                                                                                                          
            bool control = true; // Flagga för att hålla programmet igång i en loop                                                
                                                                                                                                   
                                                                                                                                   
            while (control) // Loop för att låta användaren välja alternativ                                                       
            {                                                                                                                      
                Console.WriteLine("Välj ett alternativ:");                                                                             
                Console.WriteLine("1. Beräkna Windchill-faktor");                                                                      
                Console.WriteLine("2. Avsluta");                                                    
                
                
                string choice = Console.ReadLine();                                                                                
                                                                                                                                   
                switch (choice)                                                                                                    
                {                                                                                                                  
                    case "1":                                                                                                      
                        CalculateWindChill(); // Användaren väljer att beräkna Windchill-faktorn                                   
                        break;                                                                                                     
                                                                                                                                   
                    case "2":                                                                                                      
                        Console.WriteLine("Programmet avslutas."); // Avsluta programmet                                           
                        control = false;                                                                                           
                        break;                                                                                                     
                                                                                                                                   
                    default:                                                                                                       
                        Console.WriteLine("Ogiltigt val, försök igen."); // Ogiltigt val                                           
                        break;                                                                                                     
                }                                                                                                                  
            }                                                                                                                      
        }                                                                                                                          
                                                                                                                                   
                                                                                                                                   
        static void CalculateWindChill() // Metod för att beräkna Windchill-faktorn                                                
        {                                                                                                                          
            double temperature = GetTemperature(); // Begär användarens inmatning för temperatur i Celsius                         
            double windSpeed = GetWindSpeed(); // Begär användarens inmatning för vindhastighet och enhet                          
                                                                                                                                   
            double windchill = CalculateWindChillFactor(temperature, windSpeed); // Beräkna Windchill-faktorn                      
            DisplayWindChill(windchill); // Visa Windchill-faktorn                                                                 
        }                                                                                                                          
                                                                                                                                   
        static double GetTemperature() // Metod för att begära användarens inmatning för temperatur i Celsius                      
        {                                                                                                                          
            Console.WriteLine("Ange utomhustemperatur i Celsius:");                                                                
            double temperature; // Variabel för att lagra temperatur                                                               
            while (!double.TryParse(Console.ReadLine(),                                                                            
                       out temperature)) // Kontrollera att inmatningen är ett giltigt tal                                         
            {                                                                                                                      
                Console.WriteLine(                                                                                                 
                    "Ogiltig inmatning. Ange en giltig temperatur i Celsius."); // Felmeddelande vid ogiltig inmatning             
            }                                                                                                                      
                                                                                                                                   
            return temperature; // Returnera temperatur                                                                            
        }                                                                                                                          
                                                                                                                                   
        static double GetWindSpeed() // Metod för att begära användarens inmatning för vindhastighet och enhet                     
        {                                                                                                                          
            Console.WriteLine(                                                                                                     
                "Ange vindhastighet ange enhet som 'km/h' eller 'm/s'):"); // Begär användarens inmatning för vindhastighet och enh
            Console.WriteLine(" 1. km/h \n 2. m/s"); // Visa alternativ för enhet                                                  
            double windspeed; // Variabel för att lagra vindhastighet                                                              
            string windUnit = Console.ReadLine();                                                                        
                                                                                                                                   
            while (true)                                                                                                           
            {                                                                                                                      
                if (windUnit == "1")                                                                                               
                {                                                                                                                  
                    Console.WriteLine(                                                                                             
                        "Ange vindhastighet i km/h:"); // Begär användarens inmatning för vindhastighet i km/h                     
                    if (double.TryParse(Console.ReadLine(),                                                                        
                            out windspeed)) // kontrollera att inmatningen är ett giltigt tal                                      
                    {                                                                                                              
                        break;                                                                                                     
                    }                                                                                                              
                    else                                                                                                           
                    {                                                                                                              
                        Console.WriteLine("Ogiltig inmatning. Ange en giltig vindhastighet i km/h.");                              
                    }                                                                                                              
                }                                                                                                                  
                else if (windUnit == "2")                                                                                          
                {                                                                                                                  
                    Console.WriteLine("Ange vindhastighet i m/s:");                                                                
                    if (double.TryParse(Console.ReadLine(),                                                                        
                            out windspeed)) // kontrollera att inmatningen är ett giltigt tal                                      
                    {                                                                                                              
                        windspeed *= 3.6; // Konvertera vindhastigheten från m/s till km/h                                         
                        break;                                                                                                     
                    }                                                                                                              
                    else                                                                                                           
                    {                                                                                                              
                        Console.WriteLine("Ogiltig inmatning. Ange en giltig vindhastighet i m/s.");                               
                    }                                                                                                              
                }                                                                                                                  
                else                                                                                                               
                {                                                                                                                  
                    Console.WriteLine("Ogiltig enhet. Ange antingen 'km/h' eller 'm/s'.");                                         
                    windUnit = Console.ReadLine();                                                                       
                }                                                                                                                  
            }                                                                                                                      
                                                                                                                                   
            return windspeed; // Returnera vindhastighet                                                                           
        }                                                                                                                          
                                                                                                                                   
        static double                                                                                                              
            CalculateWindChillFactor(double temperature,                                                                           
                double windspeed) // Metod för att beräkna Windchill-faktorn                                                       
        {                                                                                                                          
            return 13.12 + 0.6215 * temperature - 11.37 * Math.Pow(windspeed, 0.16) +                                              
                   0.3965 * temperature * Math.Pow(windspeed, 0.16);                                                               
        }                                                                                                                          
                                                                                                                                   
        static void DisplayWindChill(double windchill)                                                                             
        {                                                                                                                          
            string windchillFormatted = String.Format("{0:0.0}", windchill); // Formatera Windchill-faktorn                        
            Console.WriteLine($"Wind Chill faktorn är {windchillFormatted}°C");                                                    
                                                                                                                                   
            string view;                                                                                                          
            if (windchill > -25)                                                                                                   
            {                                                                                                                      
                view = "Kallt";                                                                                                   
            }                                                                                                                      
            else if (windchill <= -25 && windchill > -35)                                                                          
            {                                                                                                                      
                view = "Mycket kallt";                                                                                            
            }                                                                                                                      
            else if (windchill <= -35 && windchill > -60)                                                                          
            {                                                                                                                      
                view = "Risk för frostskada";                                                                                     
            }                                                                                                                      
            else                                                                                                                   
            {                                                                                                                      
                view = "Stor risk för frostskada";                                                                                
            }                                                                                                                      
                                                                                                                                   
            Console.WriteLine($"Klassificering: {view}");                                                                         
        }                                                                                                                          
    }                                                                                                                              
}                      
