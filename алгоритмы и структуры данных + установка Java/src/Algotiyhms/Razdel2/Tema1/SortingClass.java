package Algotiyhms.Razdel2.Tema1;

public  class SortingClass {

    public  int[] generateArray (int numberOfElements){
        int[] array = new int[numberOfElements];
        for(int i = 0; i < numberOfElements; i++){
            array[i] = (int) (Math.random()*100000);
        }
    return  array;}


    public  int[] bubbleSorting (int[] array){

        for(int i = array.length - 1; i > 0; i--){
        for(int j = 0; j < i; j++) {
            if (array[j] > array[j + 1]) {
                int x = array[j];
                array[j] = array[j + 1];
                array[j + 1] = x;
            }
        }

        }
    return array;}

    public int[] insertionSorting (int[] array){
        for (int i = 0; i < array.length - 1; i++){
            if (array[i] > array [i + 1]){
                int y = array[i];
                array[i] = array[i + 1];
                array[i + 1] = y;

                for(int j = i ; j > 0; j--) {
                    if (array[j - 1] > array [j]) {
                        int x = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = x;
                    }
                }
            }
        }

    return array;}

    public int[] chooseSorting(int[] array){
        for(int i = 0; i < array.length - 1; i ++){
           int indexMin = i;
                for(int j = i; j < array.length - 1; j ++){
                    if( array[indexMin] > array[j + 1]) {
                        indexMin = j + 1;
                        j = indexMin;
                    }
                }
                if(indexMin != 0) {
                    int x = array[i];
                    array[i] = array[indexMin];
                    array[indexMin] = x;
                }
        }
    return array;}

    public  void printArray(int[] array) {
        for (int i = 0; i < array.length; i++) {
            System.out.print(array[i] + " ");
        }
        System.out.println();
    }
}
