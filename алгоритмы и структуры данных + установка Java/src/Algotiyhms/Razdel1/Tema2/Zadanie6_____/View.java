package Algotiyhms.Razdel1.Tema2.Zadanie6_____;


public class View {
    public View(DynamicQueue array) {
        for(int i = 0; i < array.getLength(); i++){
            System.out.print(array.getArray()[i] + " ");
        }
        System.out.println();


    }
}
