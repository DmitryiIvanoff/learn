package JavaCore.laba1_2.Part1;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WorkWithArray {



    public int[] parseArray(String string){
        int[] array;
        String[] arrayOfStrings = string.split("\\D+");
            int length = 0;
        for (int i = 0; i < arrayOfStrings.length; i++) {
            if(arrayOfStrings[i].equals("")){
             length--;
            }
            else{
                length++;
            }
        }
        array = new int[length + 1];
            for (int i = 0 , j = 0; i < arrayOfStrings.length; i++) {
                if(!arrayOfStrings[i].equals("")) {
                    array[j] = Integer.parseInt(arrayOfStrings[i]);
                    j++;
                }
            }
        return array;
    }

    public double[] parseArrayDouble(String string){
        double[] array;
        String[] arrayOfStrings = string.split("[^\\d\\.]+" );
        int length = 0;
        for (int i = 0; i < arrayOfStrings.length; i++) {
            if(arrayOfStrings[i].equals("")){
                length--;
            }
            else{
                length++;
            }
        }
        array = new double[length + 1];
        for (int i = 0 , j = 0; i < arrayOfStrings.length; i++) {
            if(!arrayOfStrings[i].equals("")) {
                try {
                    Pattern p = Pattern.compile("^\\.{1,}$");
                    Matcher m = p.matcher(arrayOfStrings[i]);
                    if(m.find()){
                        throw new ExceptionNotNumber(arrayOfStrings[i]);
                    }
                    array[j] = Double.parseDouble(arrayOfStrings[i]);
                }
                catch (ExceptionNotNumber t){
                    System.out.println("ne tot format chisla: " + t.getMessage());
                    System.exit(1);
                }
                j++;
            }
        }
        return array;
    }

    public int[] generateArray(int count){
        int[] array = new int[count];
        for (int i= 0; i < count; i++) {
            array[i] = (int)(Math.random()*100);
        }

    return array;}


    public int findAverage(int[] array){

        int sum = 0;
        for(int i = 0; i < array.length; i++){
            sum += array[i];
        }
        if(array.length > 0) {
         return sum / array.length;
        }
    return 0;}

    public double findAverage(double[] array){

        double sum = 0;
        for(int i = 0; i < array.length; i++){
            sum += array[i];
        }
        if(array.length > 0) {
            return sum / array.length;
        }
        return 0;}



    public int findMaximum(int[] array){
        int max = array[0];
        for(int i = 0; i < array.length; i++){
            if(array[i] > max){
                max = array[i];
            }
        }
        return max;}


    public double findMaximum(double[] array){
        double max = array[0];
        for(int i = 0; i < array.length; i++){
            if(array[i] > max){
                max = array[i];
            }
        }
        return max;}






    public int findMinimum(int[] array){
        int min = array[0];
        for(int i = 0; i < array.length; i++){
            if(array[i] < min){
                min = array[i];
            }
        }
        return min;}


    public double findMinimum(double[] array){
        double min = array[0];
        for(int i = 0; i < array.length; i++){
            if(array[i] < min){
                min = array[i];
            }
        }
        return min;}





    public long findMultiplication(int[] array){
        long multiplication = array[0];
        for(int i = 0; i < array.length; i++){
                multiplication *= array[i];

        }
        return multiplication;}


    public double findMultiplication(double[] array){
        double multiplication = array[0];
        for(int i = 0; i < array.length; i++){
            multiplication *= array[i];

        }
        return multiplication;}




    public long findSum(int[] array){
        long sum = array[0];
        for(int i = 0; i < array.length; i++){
            sum += array[i];

        }
        return sum;}



    public double findSum(double[] array){
        double sum = array[0];
        for(int i = 0; i < array.length; i++){
            sum += array[i];

        }
        return sum;}



    public long findSubstraction(int[] array){
        long substraction = array[0];
        for(int i = 0; i < array.length; i++){
            substraction -= array[i];

        }
        return substraction;}


    public double findSubstraction(double[] array){
        double substraction = array[0];
        for(int i = 0; i < array.length; i++){
            substraction -= array[i];

        }
        return substraction;}





        public void print(double[] array){
            for (double r: array) {
                System.out.print(r + " ");
            }
            System.out.println();
        }

}
