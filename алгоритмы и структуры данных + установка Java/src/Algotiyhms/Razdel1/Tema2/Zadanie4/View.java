package Algotiyhms.Razdel1.Tema2.Zadanie4;



public class View {
    public View(Stack array) {
        for(int i = 0; i < array.getLength(); i++){
            System.out.print(array.getArray()[i] + " ");
        }
        System.out.println();


    }
}
