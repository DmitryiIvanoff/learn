package Algotiyhms.Razdel1.Tema2.Zadanie4;

public class DeletedStack {
public DeletedStack(int i){
    Dialog.getDeletedArray().push(i);
    Dialog.setDeletedArray(Dialog.getDeletedArray());
}
}
