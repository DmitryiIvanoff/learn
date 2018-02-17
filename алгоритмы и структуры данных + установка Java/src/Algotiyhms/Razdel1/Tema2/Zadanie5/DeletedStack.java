package Algotiyhms.Razdel1.Tema2.Zadanie5;

public class DeletedStack {
public DeletedStack(int i){
    Dialog.getDeletedArray().add(i);
    Dialog.setDeletedArray(Dialog.getDeletedArray());
}
}
