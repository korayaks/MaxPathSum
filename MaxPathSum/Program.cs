using System;
using System.IO;

namespace MaxPathSum
{
    class Program
    {
        private const string inputString =
@"215
193 124
117 237 442
218 935 347 235
320 804 522 417 345
229 601 723 835 133 124
248 202 277 433 207 263 257
359 464 504 528 516 716 871 182
461 441 426 656 863 560 380 171 923
381 348 573 533 447 632 387 176 975 449
223 711 445 645 245 543 931 532 937 541 444
330 131 333 928 377 733 017 778 839 168 197 197
131 171 522 137 217 224 291 413 528 520 227 229 928
223 626 034 683 839 053 627 310 713 999 629 817 410 121
924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";


        static void Main(string[] args)
        {
            int[,] array2D = convert2D(inputString);
            Console.WriteLine("Maximum sum of input = " + maxPathSum(array2D));
            Console.WriteLine("Enter the input file ex-> " + @"(C:\Users\username\Desktop\input.txt)");//dosyadan oku
            string filePath = Console.ReadLine();
            string fileInput=null;
            if (File.Exists(filePath))
            {
                fileInput = File.ReadAllText(filePath);
            }
            else
            {
                Console.WriteLine("Please control your input file !");
                System.Environment.Exit(0);
            }      
            int[,] fileArray2D = convert2D(fileInput);
            Console.WriteLine("Maximum sum of input = " + maxPathSum(fileArray2D));
        }
        public static int[,] convert2D(string inputString)
        {
            string[] tempArray = inputString.Split(' ', '\n');// Verilen "inputString" stringini boşluk karakteri ve \n karakterine göre ayırıyorum.
            int arrayRowAndColumnLength = 0;

            for (int i = 0; i < 10000; i++)//arr1.lenght = n(n+1)/2 olmalı. Örneğin
            {                                                      //1          soldaki üçgende toplam 10 (1+2+3+4) tane sayı var ve her satırda ardışık olarak artıyor
                if (((i * i) + i) / 2 == tempArray.Length)         //8 4        5 satır olsaydı 15 (1+2+3+4+5) olurdu. Sonuc olarak verilen stringdeki toplam eleman sayısı
                {                                                  //2 6 9      ardışık sayıların toplamlarının katı olmak zorunda ve bunu kontrol ediyorum.
                    arrayRowAndColumnLength = i;                   //8 5 9 3    Eğer verilen string hatalı veya doğru formatta değil ise hata vermesini sağlıyorum
                    break;

                }
            }
            if (arrayRowAndColumnLength == 0) //ardışık sayıların toplamının herhangi bir katı değil ise  
            {
                Console.WriteLine("Please control your input string or input file !");
                System.Environment.Exit(0);
            }
            int[] intArray = ControlPrime(tempArray);//tempArray dizisindeki tüm elemanların asal sayı olup olmadığını kontrol ediyorum.
            int[,] array2D = new int[arrayRowAndColumnLength, arrayRowAndColumnLength];//oluşturulan dizi aslında bir kare matris 
            int indexCounter = 0;                                                        //bu yüzden satır ve sütun uzunlukları eşit
            for (int i = 0; i < arrayRowAndColumnLength; i++)
            {
                for (int k = 0; k <= i; k++)
                {
                    array2D[i, k] = intArray[indexCounter];    //tek boyutlu diziyi iki boyutlu diziye dönüştürüyorum.
                    indexCounter++;
                }
            }
            return array2D;
        }
        public static int[] ControlPrime(string[] tempArray)
        {
            int[] intArray = new int[tempArray.Length];//yeni bir int dizi oluşturuyorum
            for (int i = 0; i < tempArray.Length; i++)//parametre ile gelen string türündeki diziyi 
            {                                        //yeni oluşturduğum int türünden olan diziye atıyorum.
                intArray[i] = Convert.ToInt32(tempArray[i]);
            }
            int tempNumber = 0, tempNumber2 = 0, isPrime = 0;//Asal sayı kontrolü için gerekli değişkenleri oluşturdum.
            for (int k = 0; k < tempArray.Length; k++)//Asal sayı kontrolü yaptım.
            {
                tempNumber = intArray[k];
                tempNumber2 = tempNumber / 2;
                for (int i = 2; i <= tempNumber2; i++)
                {
                    if (tempNumber % i == 0)
                    {
                        isPrime = 1;
                        break;//Asal sayı değil ise isPrime değişkeni 1 değerini alıyor
                    }
                }
                if (isPrime == 0)//isPrime değişkeni 0 ise kontrol edilen sayı asal sayı demektir.
                {
                    intArray[k] = 0;//kontrol edilen sayıyı 0 yapıyorum.
                                    //sonuç olarak dizimdeki tüm asal sayılar 0 oldu, geri kalanına dokunmadım.
                }
                isPrime = 0;
            }
            return intArray;
        }
        static int maxPathSum(int[,] array2D)
        {
            int n = (int)(Math.Sqrt(array2D.Length)) - 1;

            for (int i = n - 1; i >= 0; i--)//verilen 2 boyutlu diziyi aşağıdan yukarıya doğru topluyorum. 
            {
                for (int j = 0; j <= i; j++)//Dizinin her elementi için seçilen elementin altına ve sağ alt çaprazındaki 
                {                           //iki elemente bakılır hangisi büyük ise onu seçip kendine ekler.
                                            //Bu olay iki boyutlu dizinin sondan bir önceki satırından başlayıp yukarıya doğru
                                            //yani iki boyutlu dizinin ilk satırına kadar devam eder.
                                            //Tüm işlemler yapıldığında iki boyutlu dizinin [0,0] elementinde en uzun yolu elde ediyorum.
                                            //Asal olan sayıları 0 yapmıştım. Bunun sebebi aslında uzun olan fakat asal sayı üzerinden gidilen yolu iptal
                                            //etmek istemem, 0 yaparak bu yolun en uzun yol olmasını engelliyorum.

                    if (array2D[i + 1, j] > array2D[i + 1, j + 1])//Dizideki seçilen elementin altındaki değer sağ alt çaprazındaki değerden büyük ise
                    {                                             //altındaki değeri kendisine ekler.
                        array2D[i, j] += array2D[i + 1, j];
                    }
                    else
                    {
                        if (array2D[i + 1, j + 1] == 0 && array2D[i + 1, j] == 0)//Eğer dizinin seçilen elementinin altındaki ve sağ alt çaprazındaki değer
                        {                                                     //0 ise (iki değerinde sıfır olması demek bu yolun bir nevi çıkmaz yol anlamına gelmesi demek)
                            array2D[i, j] = 0;                                //bu durumda seçilen elementi 0 değerine eşitliyorum yani bir nevi asal sayı gibi davranıyorum.
                        }
                        else
                        {
                            array2D[i, j] += array2D[i + 1, j + 1];//Dizinin seçilen elementinin sağ alt çaprazındaki değer altındaki değerden büyük ise                                                                  
                        }                                          //sağ alt çaprazdaki değeri kendine ekler.                

                    }
                    //Örneğin bize yandaki gibi       2  0  0               2  0  0                16  0  0 
                }      //bir giriş verilse aşamalar      4  5  0  --------->   13 14 0  --------->            ----> array[0,0] = 16 en uzun yol olur
            }          //görüntü olarak yandaki gibi     8  9  5                              
            return array2D[0, 0];//aşağıdan yukarıya doğru toplama sonucunda iki boyutlu dizinin ilk elemanı
        }                        //bize en uzun yolu veriyor.
    }
}
