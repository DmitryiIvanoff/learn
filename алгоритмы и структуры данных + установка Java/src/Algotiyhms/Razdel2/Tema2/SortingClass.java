package Algotiyhms.Razdel2.Tema2;

public  class SortingClass {
    public  int[] generateArray (int numberOfElements){
          int[] array = new int[numberOfElements];
         for(int i = 0; i < numberOfElements; i++){
            array[i] = (int) (Math.random()*10000);
         }

        return array ;}

    public  int[] generateArray2 (int numberOfElements){
        //  int[] array = new int[numberOfElements];
        // for(int i = 0; i < numberOfElements; i++){
        //    array[i] = (int) (Math.random()*10000);
        // }
        int [] array = {15 , 33,  42,  7,  12,  19};
        return array ;}

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

    public int[] shellSort(int[] array){
        int[] step = { 1, 2, 3, 7, 15, 31, 63, 127, 255, 511, 1023, 2047, 4095, 8191, 16383, 32767 };
        int stepIndex = 0;
        for(int i = 0; i < step.length; i++){
            if (step[i] < array.length ){
                stepIndex = i;
            }
            else{
                break;
            }
        }

        for ( int z ; stepIndex >= 0; stepIndex--) {
            z = step[stepIndex];
            for (int i = 0; i < array.length - z; i ++) {
                if (array[i] > array[i + z]) {
                    int y = array[i];
                    array[i] = array[i + z];
                    array[i  + z] = y;

                    for (int j = i; j >= z; j -=z) {
                        if (array[j - z ] > array[j]) {
                            int x = array[j  - z];
                            array[j  - z] = array[j];
                            array[j] = x;
                        }
                    }
                }
            }
        }
        return array;}

        public int[] fastSorting (int[]array){
            int centerIndex = array.length / 2;
            boolean isLeftFound = false;
            boolean isRightFound = false;
            int tempBig, tempSmallIndex = 0, tempBigIndex = 0;
            while (true){
                if(array.length == 2){
                    if(array[0] > array[1]){
                        int temp = array[0];
                        array[0] = array[1];
                        array[1] = temp;
                    }
                    break;
                }
                for (int j = array.length - 1; j > centerIndex; j--) {
                    if (array[j] <= array[centerIndex]){
                        tempSmallIndex = j;
                        isRightFound = true;
                        break;
                    }
                }
                for (int i = 0; i < centerIndex; i++) {
                    if(array[i] > array[centerIndex]){ //kogda naydeno i levoe i pravoe
                       tempBigIndex = i;
                      isLeftFound = true;
                        break;
                    }
                }
                if(isLeftFound == true && isRightFound == true){
                    tempBig = array[tempBigIndex];
                    array[tempBigIndex] = array[tempSmallIndex];
                    array[tempSmallIndex] = tempBig;
                   isLeftFound = false;
                   isRightFound = false;
                }
                else{
                    if(isLeftFound == true && isRightFound == false){
                        tempBig = array[tempBigIndex];
                        for (int z = tempBigIndex; z < array.length - 1; z++) { //sdvigaem
                            array[z] = array[z + 1];
                        }
                        array[array.length - 1] = tempBig;
                        centerIndex--;
                        isLeftFound = false;
                        isRightFound = false;
                    }
                    else{
                        if(isRightFound == true && isLeftFound == false){
                            for (int j = tempSmallIndex; j > centerIndex; j--) {
                                if (array[j] <= array[centerIndex]) {
                                    int temp = array[j];
                                    for (int h = j; h > 0; h--) {
                                        array[h] = array[h - 1];
                                    }
                                    array[0] = temp;
                                    centerIndex++;
                                    j++;
                                }
                            }
                            isLeftFound = false;
                            isRightFound = false;
                        }
                        else{
                            if(isLeftFound == false && isRightFound == false){
                                break;
                            }
                        }
                    }
                }


            }

        if(array.length > 2){
            int[] left = new int[centerIndex];
            int[] right = new int[array.length - left.length];
            System.arraycopy(array, 0, left, 0, centerIndex);
            System.arraycopy(array, centerIndex , right, 0, array.length -centerIndex );
            left = fastSorting(left);
            for (int i = 0; i < left.length; i ++){
                array[i] = left[i];
            }
            right = fastSorting(right);
            for (int i = right.length - 1, j = array.length - 1; i >= 0 ; i--, j--){
                array[j] = right[i];
            }
        }
    return array;}



    public void upgradedChooseSorting(int[] array){
       int firstHalfEndIndex = array.length / 2;
       int secondHalfStartIndex = firstHalfEndIndex + 1;
       for (int i = firstHalfEndIndex - 1; i >=0; i--){
           int tempIndex;
           if((2 * i + 2) <= array.length - 1){
               if(array[2 * i + 1] > array[2 * i + 2]){
                   tempIndex = 2 * i + 2;
               }
               else {
                   tempIndex = 2 * i + 1;
               }
           }
           else{
               tempIndex = 2 * i + 1;
           }

           if(array[i] > array[tempIndex]){
               int temp = array[i];
               array[i] = array[tempIndex];
               array[tempIndex] = temp;
               if(tempIndex < firstHalfEndIndex) {
                   int tempIndex2;
                   if ((2 * tempIndex + 2) <= array.length - 2) {
                       if (array[2 * tempIndex + 1] > array[2 * tempIndex + 2]) {
                           tempIndex2 = 2 * tempIndex + 2;
                       } else {
                           tempIndex2 = 2 * tempIndex + 1;
                       }

                   }
                   else{
                       tempIndex2 = 2 * tempIndex + 1;
                   }
                   if (array[tempIndex] > array[tempIndex2]) {
                       temp = array[tempIndex2];
                       array[tempIndex2] = array[tempIndex];
                       array[tempIndex] = temp;
                       if(tempIndex2 < firstHalfEndIndex){
                           i = tempIndex2 + 1;
                       }
                   }
               }
           }
       }

       for(int i = array.length - 1, z = 0, j; i > 0; i--) {
           j = z;
           int temp = array[j];
           array[j] = array[i];
           array[i] = temp;
           int tempIndexLeft, tempIndexRight;
           for(j = 0; j < i - 1; j++ ){
           if (2 * j + 2 < i) {
               if (j == 0) {
                   tempIndexLeft = 1;
                   tempIndexRight = 2;
               } else {
                   tempIndexLeft = 2 * j +1;
                   tempIndexRight = 2 * j + 2;
               }
           } else {
               if(2 * j + 1 < i) {
                   tempIndexRight = tempIndexLeft = 2 * j + 1;
               }
               else {
                   break;
               }
           }
           int tempIndex;
           if (array[tempIndexLeft] < array[tempIndexRight]) {
               tempIndex = tempIndexLeft;
           } else {
               tempIndex = tempIndexRight;
           }
           if (array[j] > array[tempIndex]) {
               int temp2 = array[j];
               array[j] = array[tempIndex];
               array[tempIndex] = temp2;
               j = tempIndex - 1;
           }

       }
       }



    }




    public  void printArray(int[] array) {
        for (int i = 0; i < array.length; i++) {
            System.out.print(array[i] + " ");
        }
        System.out.println();
    }

    public  void printArrayFromEnd(int[] array) {
        for (int i = array.length - 1; i >= 0; i--) {
            System.out.print(array[i] + " ");
        }
        System.out.println();
    }



}
