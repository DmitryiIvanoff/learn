package JavaCore.laba1_2.Part3____;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class WorkWithArray {


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


    public static double getSum(double[] array, int pow){
        double sum = 0;
        for (double d: array) {
            sum += Math.pow(d, pow);
        }
        return sum;
    }

    public static double getSubstraction(double[] array, int pow){
        double sub = 0;
        for (double d: array) {
            sub -= Math.pow(d, pow);
        }
        return sub;
    }


    public static double getMultiplication(double[] array, int pow){
        double mult = 0;
        for (double d: array) {
            mult *= Math.pow(d, pow);
        }
        return mult;
    }

    public static double getDivision(double[] array, int pow){
        double div = 0;
        for (double d: array) {
            div /= Math.pow(d, pow);
        }
        return div;
    }






        public void print(double[] array){
            for (double r: array) {
                System.out.print(r + " ");
            }
            System.out.println();
        }

}
