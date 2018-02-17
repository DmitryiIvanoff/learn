package Algotiyhms.Razdel1.Tema3.Zadanie4;

public class ListElement {
    ListElement next;
    int data;
    int index;

    public ListElement(int data) {
        this.data = data;
    }

    public boolean hasNext(){
        if(this.next != null){
            return true;
        }
        else {
            return false;
        }
    }
}
