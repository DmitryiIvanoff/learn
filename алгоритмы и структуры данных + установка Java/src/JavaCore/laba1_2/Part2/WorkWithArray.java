package JavaCore.laba1_2.Part2;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Locale;
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


    public static double getSumSinuses(double[] angles, int type){
        double sum = 0;
        if(type == 1){
            for (double d:angles) {
                sum += Math.sin(d);
            }
        }else {
            for (double d:angles) {
                sum += (Math.sin(d * 180 / Math.PI));
            }
        }
    return  sum;}

    public static double getSumCosines(double[] angles, int type){
        double sum = 0;
        if(type == 1){
            for (double d:angles) {
                sum += Math.cos(d);
            }
        }else {
            for (double d:angles) {
                sum += (Math.cos(d * 180 / Math.PI));
            }
        }
        return  sum;}

    public static double getSubstractionCosines(double[] angles, int type){
        double sub = 0;
        if(type == 1){
            for (double d:angles) {
                sub += Math.cos(d);
            }
        }else {
            for (double d:angles) {
                sub -= (Math.cos(d * 180 / Math.PI));
            }
        }
        return  sub;}


    public static double getSubstractionSines(double[] angles, int type){
        double sub = 0;
        if(type == 1){
            for (double d:angles) {
                sub += Math.sin(d);
            }
        }else {
            for (double d:angles) {
                sub -= (Math.sin(d * 180 / Math.PI));
            }
        }
        return  sub;}


    public static double getSumSinuses(double[] angles, int type, int decimals){
        double sum = 0;
        if(type == 1){
            for (double d:angles) {
                sum += Math.sin(d);
            }
        }else {
            for (double d:angles) {
                sum += (Math.sin(d * 180 / Math.PI));
            }
        }

       double d =  new BigDecimal(sum).setScale(decimals,BigDecimal.ROUND_HALF_EVEN).doubleValue();
        return  d;}









        public void print(double[] array){
            for (double r: array) {
                System.out.print(r + " ");
            }
            System.out.println();
        }

}
