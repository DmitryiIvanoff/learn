package Algotiyhms.Razdel1.Tema4.Zadanie3;

public class ListOfLinkedLists {
    LinkedList first, last;

    public void addNewList(int listIndex){
            LinkedList newListOfLists = new LinkedList();
            if(first == null){
                newListOfLists.listIndex = 0;
                first = newListOfLists;
                last = newListOfLists;
            }
            else{
                LinkedList temp = first;
                LinkedList saveNextIndex;
                if(last.listIndex + 1 == listIndex ){
                    saveNextIndex = last;
                    last = newListOfLists;
                    last.previous = saveNextIndex;
                    saveNextIndex.next = last;
                    last.listIndex = saveNextIndex.listIndex + 1;
                }
                else {
                    do {
                        if (listIndex == 0) {   //вставка в начало списка
                            saveNextIndex = first;
                            first = newListOfLists;
                            newListOfLists.next = saveNextIndex;
                            saveNextIndex.previous = newListOfLists;
                            saveNextIndex.listIndex++;
                            while (temp.hasNext()) {
                                temp = temp.next;
                                temp.listIndex++;
                            }
                            break;
                        }
                        if (temp.listIndex == listIndex - 1) { //останавливаемся на элементе, предществующему значению  listIndex
                            saveNextIndex = temp.next; //сохраняем во временную ссылку значение ссылки на объект listIndex
                            temp.next.previous = newListOfLists;
                            temp.next = newListOfLists; //
                            temp.next.listIndex = listIndex;
                            newListOfLists.next = saveNextIndex;
                            newListOfLists.previous = temp;
                            temp = temp.next;
                            while (temp.hasNext()) {
                                temp = temp.next;
                                temp.listIndex++;
                            }
                            break;
                        }
                        temp = temp.next;
                    }
                    while (temp.hasNext());
                }
            }
        }


    public  LinkedList getLinkedList(int listIndex){
       if(listIndex == 0 && first != null){
           return first;
       }
       else {
           if (listIndex == last.listIndex) {
               return last;
           } else {
               LinkedList temp = first;
               while (temp.hasNext()) {
                   if (temp.listIndex == listIndex) {
                       return temp;
                   }
                   temp = temp.next;
               }
           }
       }
        return null;
    }

    public void printList(){
       if(first != null){
           System.out.println(first.getClass().getSimpleName() + " listIndex = " + first.listIndex);
           LinkedList f = first;
           first.printList();
           while (f.hasNext()){
               f = f.next;
               System.out.println();
               System.out.println(f.getClass().getSimpleName() + " listIndex = " + f.listIndex);
               f.printList();
           }
           System.out.println();
       }
       else{
           System.out.println("ListOfLinkedLists is empty");
       }
        System.out.println("======================");
    }

    public void search(int key ) {
        if (first != null) {
                LinkedList f = first;
                while (f != null) {
                    ListElement z = f.head;
                    while (z.hasNext()) {
                        if (z.data == key) {
                            System.out.println(f + " listIndex = " + f.listIndex + "; " + z.data + " - index = " + z.index  + "\n");
                        }
                        z = z.next;
                    }
                    if (f.tail.data == key) {
                        System.out.println(f + " listIndex = " + f.listIndex + "; " + f.tail.data + " - index = " + f.tail.index  + "\n");
                    }
                    f = f.next;
                }
        }
        else{
            System.out.println("LinkedList is empty");
        }
    }

    public void delete(int index){
        if(first != null ){
            LinkedList temp = first;
            if(index <= last.listIndex) {
                if(first == last){
                    first = null;
                }
                while (temp.hasNext()) {
                    if (index == 0) {
                        first = temp.next;
                        first.previous = null;

                        while (temp.hasNext()) {
                            temp = temp.next;
                            temp.listIndex--;
                        }
                        break;
                    } else {
                        if (temp.listIndex == index - 1) {
                            temp.next = temp.next.next;
                            temp.next.previous = temp;

                            while (temp.hasNext()) {
                                temp = temp.next;
                                temp.listIndex--;
                            }
                            break;
                        }

                    }
                    temp = temp.next;
                }

            }
            else System.out.println("OutOfIndex");
        }
        else{
            System.out.println("LinkedList is empty");
        }

    }
}
