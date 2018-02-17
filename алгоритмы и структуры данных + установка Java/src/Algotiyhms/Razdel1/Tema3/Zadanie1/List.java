package Algotiyhms.Razdel1.Tema3.Zadanie1;

public class List {
    private Object[] array;
    private int  maxSize;

    public List(int maxSize) {
        this.maxSize = maxSize;
        this.array = new Object[maxSize];
    }

    public void add(Object e, int index) {
        if(array[index] == null){
            array[index] = e;
        }
        else{
            if(array[array.length - 1] == null){
                for (int i = array.length - 2; i >= index; i--) {
                    array[i + 1] = array[i];
                }
                array[index] = e;
            }
            else
            {
                System.out.println("viberete druguyu pustuyu yacheiku iz sleduyushih: ");
                for (int j = 0; j < array.length; j++) {
                    if (array[j] == null) {
                        System.out.print(j + ", ");
                    }
                }
                System.out.println();
            }
        }
    }


    public void remove(int index) {
        if(array[index] != null){
            array[index] = null;
            for (int i = index; i < array.length - 1; i++ ){
                array[i] = array[i + 1];
            }
            array[array.length - 1] = null;
        }

    }


    public void view() {
        for(int i = 0; i < array.length; i++){
            System.out.print(array[i] + " ");
        }
        System.out.println();
    }

     public void search(int data){
         for (Object r:array
              ) {
             if (r != null && r instanceof Number && (int)r == data){
                 System.out.println(r);
                 break;
             }
         }
     }
}
