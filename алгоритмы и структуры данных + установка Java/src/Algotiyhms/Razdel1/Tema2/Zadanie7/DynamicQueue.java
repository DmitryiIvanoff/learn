package Algotiyhms.Razdel1.Tema2.Zadanie7;

public class DynamicQueue {
    Object[] array;
    int first = 0, last = -1, elementCount = 0, maxSize;

    public DynamicQueue(int size) {
        this.maxSize = size;
        this.array = new Object[size];
    }

    public int getLength() {
        return array.length;
    }

    public Object[] getArray() {
        return array;
    }

    public void add(Object e){

        if(last < array.length - 1) {
            last++;
            array[last] = e;
            elementCount++;
        }
        else{
          Object[] temp = new Object[array.length + 1];
          int tempLastDigit = 0;
          for (int i = 0, j = 0; i < array.length; i++){
              if(array[i] != null) {
                  temp[j] = array[i];
                  j++;
                  tempLastDigit = j;
              }
          }
          array = null;
            first = 0;
            temp[tempLastDigit] = e;
            elementCount++;
            array = new Object[tempLastDigit + 1];
            for (int i = 0; i < array.length; i++){
            array[i] = temp[i];
            }
            last = array.length - 1;
        }

    }

    public void remove() {
      if(elementCount > 0){
           array[first] = null;
           elementCount--;
           if(first < array.length -1){
               first++;
           }
           else{
               first = 0;
           }
      }
      else{
          System.out.println("Queue is empty.");
      }
    }

    public void view() {
        for(int i = 0; i < array.length; i++){
            System.out.print(array[i] + " ");
        }
        System.out.println();


    }
}
