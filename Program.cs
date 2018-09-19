using System;

namespace Espiral
{
    class Program
    {

        static int[,] mat;
        static int tam = 0;
        static int num = 10;
        static void Main(string[] args)
        {
            Console.Write("Ingresa el tamaño del arreglo: ");
            if (Int32.TryParse(Console.ReadLine(), out tam)) {
                mat = new int[tam,tam];

                for (int i=0; i<tam; i++) {
                    for (int j=0; j<tam; j++) {
                        mat[i,j] = 0;
                    }
                }

                llena(0, 0, 1, tam);
                imprimir();
            } else {
                Console.WriteLine("Debes ingresar un numero entero");
            }
        }

        public static void llena(int x, int y, int dir, int tam) {
            while (num < (tam*tam)+10) {
                if (x < tam && x >= 0 && y < tam && y >= 0) {
                    if (mat[x,y] == 0) {                    
                        mat[x,y] = num;
                        num++;
                        
                        if (dir == 1) {
                            y++;
                        } else if (dir == 2) {
                            x++;
                        } else if (dir == 3) {
                            y--;
                        } else if (dir == 4) {
                            x--;
                        }

                        llena(x,y,dir,tam);
                    } else {
                        dir++;

                        if (dir == 5) {
                            dir = (dir - 4);
                        }

                        //CAmbio de direccion 2
                        if (dir == 1) {
                            x++;
                            y++;
                        } else if (dir == 2) {
                            y--;
                            x++;
                        } else if (dir == 3) {
                            x--;
                            y--;
                        } else if (dir == 4) {
                            y++;
                            x--;

                            if(mat[(x-1),y] != 0) {
                                dir = 1;
                            }
                        }

                        if (x < tam && x >= 0 && y < tam && y >= 0) {
                            llena(x,y,dir,tam);
                        }
                    }
                } else {
                    //Cambio de direccion
                    if (dir == 1) {
                        y--;
                        x++;
                    } else if (dir == 2) {
                        x--;
                        y--;
                    } else if (dir == 3) {
                        y++;
                        x--;
                    } else if (dir == 4) {
                        x++;
                    }

                    dir++;

                    if (dir == 5) {
                        dir = (dir - 4);
                    }

                    if (x < tam && x >= 0 && y < tam && y >= 0) {
                        llena(x,y,dir,tam);
                    }
                }
            }
        }

        public static void imprimir() {
            //Console.WriteLine();
            for (int i=0; i<tam; i++) {
                for (int j=0; j<tam; j++) {
                    Console.Write(mat[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
