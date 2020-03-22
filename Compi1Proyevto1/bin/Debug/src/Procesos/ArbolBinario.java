/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Procesos;

import Objetos.Follow;
import Objetos.Lexema;
import Objetos.Nodo;
import Objetos.Token;
import Objetos.Transiciones;
import Objetos.Terminal;
import java.awt.Desktop;
import java.io.File;
import java.io.FileWriter;
import java.io.PrintWriter;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author Steven Sis
 */
public class ArbolBinario {
    private ArrayList<Token> lstToken; //Va contener la lista de tokens que conforma la expresion regular
    private ArrayList<Lexema> lstLexema = new ArrayList<Lexema> ();
    private ArrayList<Follow> lstFollow = new ArrayList<Follow> ();
    private ArrayList<Nodo> lstHojas = new ArrayList<Nodo> ();
    private ArrayList<String> lstTerminales = new ArrayList<String> ();
    private ArrayList<Transiciones> lstTransiciones = new ArrayList<Transiciones> ();
    private ArrayList<Terminal> lstT = new ArrayList<>();
    private String nombreExpresion,nombreTablaFollow;
    private int hoja;
    private Nodo raiz;
    private int i=0,estados=0; //Va llegar el control de tokens analizado en la lista de tokens que conforma la expresion regular 
    private String arbol="",follow="";
    
    public ArbolBinario(ArrayList<Token> lstToken, String nombreExpresion) {
        this.lstToken = lstToken;
        this.lstToken.add(0,new Token(Token.Tipo.PUNTO,".",lstToken.size()+1,0,0));
        this.lstToken.add(new Token(Token.Tipo.NUMERAL,"#",lstToken.size()+1,0,0));
        raiz = createArbol();
        this.nombreExpresion = nombreExpresion;
        this.nombreTablaFollow=this.nombreExpresion+"Follow";
    }
    
    public Nodo createArbol(){
        switch(lstToken.get(i).getTipoT()){
            case ASTERISCO:
                Nodo nodoAsterisco = new Nodo(lstToken.get(i));i++;
                Nodo izquierdo = createArbol(); //Para el asterisco solo va existe un nodo, se tomara el asterisco
                nodoAsterisco.setIzquierda(izquierdo); // se añade el nodo hijo 
                nodoAsterisco.setAnulable(true); //Se añade la anulabilidad, el asterisco siempre es anulable
                nodoAsterisco.setPrimeros(izquierdo.getPrimeros()); //Se añade loz primeros, los primeros seran los primeros de su nodo hijo
                nodoAsterisco.setUltimos(izquierdo.getUltimos()); //Se añade los ultimos, los ultimos seran los ultimos de su nodo hijo
                for (int j = 0; j < izquierdo.getUltimos().size(); j++) {
                        lstFollow.get(izquierdo.getUltimos().get(j)-1).getSiguientes().addAll(izquierdo.getPrimeros()); 
                        lstFollow.get(izquierdo.getUltimos().get(j)-1).noDuplicar();
                }
                return nodoAsterisco;
            case MAS:
                Nodo nodoMas = new Nodo(lstToken.get(i));i++;
                Nodo izquierdoM = createArbol(); //Para el mas solo va existe un nodo, se tomara el asterisco
                nodoMas.setIzquierda(izquierdoM); //Se añade el nodo hijo
                nodoMas.setAnulable(izquierdoM.isAnulable()); //Si el hijo es anulable el padre tambien y viseversa 
                nodoMas.setPrimeros(izquierdoM.getPrimeros()); //Los primeros del hijo son los primeros del padre
                nodoMas.setUltimos(izquierdoM.getUltimos());//Los ultimos del hijo son los ultimos del padre
                for (int j = 0; j < izquierdoM.getUltimos().size(); j++) {
                        lstFollow.get(izquierdoM.getUltimos().get(j)-1).getSiguientes().addAll(izquierdoM.getPrimeros()); 
                        lstFollow.get(izquierdoM.getUltimos().get(j)-1).noDuplicar();
                }
                return nodoMas;
            case PUNTO:
                Nodo nodoPunto = new Nodo(lstToken.get(i)); i++;
                Nodo izquierdoP = createArbol(); 
                Nodo derechoP = createArbol(); 
                nodoPunto.setIzquierda(izquierdoP);//añade nodo izquierdo a padre
                nodoPunto.setDerecha(derechoP); //Añade nodo derecho a padre
                nodoPunto.setAnulable(izquierdoP.isAnulable() && derechoP.isAnulable()); //Los dos hijos tienen que ser anulables para que el padre sea anulable
                /*Para primeros Se usa la condicion If (Anulable(C1))     
                                        F=F(C1)+F(C2)
                                        Else
                                        F=F(C1)*/
                if (izquierdoP.isAnulable()) {
                    nodoPunto.getPrimeros().addAll(izquierdoP.getPrimeros());
                    nodoPunto.getPrimeros().addAll(derechoP.getPrimeros());
                }else{
                    nodoPunto.getPrimeros().addAll(izquierdoP.getPrimeros());
                }
                 /*Para ultimos Se usa la condicion If (Anulable(C2))
                                                    L=L(C1)+L(C2)
                                                    Else
                                                    L=L(C2)*/
                if (derechoP.isAnulable()) {
                nodoPunto.getUltimos().addAll(izquierdoP.getUltimos());
                nodoPunto.getUltimos().addAll(derechoP.getUltimos());
                }else{
                    nodoPunto.getUltimos().addAll(derechoP.getUltimos());
                }
                for (int j = 0; j < izquierdoP.getUltimos().size(); j++) {
                        lstFollow.get(izquierdoP.getUltimos().get(j)-1).getSiguientes().addAll(derechoP.getPrimeros()); 
                        lstFollow.get(izquierdoP.getUltimos().get(j)-1).noDuplicar();
                }
                
                return nodoPunto;
            case INTERROGACION_DE:
                Nodo nodoI = new Nodo(lstToken.get(i)); i++;
                Nodo izquierdoI = createArbol();
                nodoI.setIzquierda(izquierdoI); //Solo tendra un hijo, lo denotaremos como izquierdo
                nodoI.setAnulable(true); //Siempre sera anulable
                nodoI.setPrimeros(izquierdoI.getPrimeros()); //Los primeros del hijo son los primeros del padre
                nodoI.setUltimos(izquierdoI.getUltimos()); //Los ultimos del hijo son los ultimos del padre
                return nodoI;
            case BARRA_V:
                Nodo nodoO = new Nodo(lstToken.get(i)); i++;
                Nodo izquierdoO = createArbol(); 
                Nodo derechoO = createArbol(); 
                nodoO.setIzquierda(izquierdoO);//añade nodo izquierdo a padre
                nodoO.setDerecha(derechoO); //Añade nodo derecho a padre
                nodoO.setAnulable(izquierdoO.isAnulable() || derechoO.isAnulable()); //Con que un hijo sea anulable, los demas seran anulables
                //Para los primeros y ultimos, sera la concatenacion de primeros de ambos hijos y la concatenacion de los ultimos de ambos hijos
                nodoO.getPrimeros().addAll(izquierdoO.getPrimeros());
                nodoO.getPrimeros().addAll(derechoO.getPrimeros());
                nodoO.getUltimos().addAll(izquierdoO.getUltimos());
                nodoO.getUltimos().addAll(derechoO.getUltimos());
                nodoO.noDuplicar();
                return nodoO;
            case ID:
                Nodo nodoID = new Nodo(lstToken.get(i)); i++;
                nodoID.setAnulable(false);   hoja++;
                nodoID.setContadorH(hoja);
                nodoID.setPrimeros(nodoID.getContadorH());
                nodoID.setUltimos(nodoID.getContadorH());
                nodoID.noDuplicar();
                lstFollow.add(new Follow(nodoID,nodoID.getContadorH()));
                return nodoID;
            case CADENA:
                Nodo nodoC = new Nodo(lstToken.get(i)); i++;
                nodoC.setAnulable(false); hoja++;
                nodoC.setContadorH(hoja);
                nodoC.setPrimeros(nodoC.getContadorH());
                nodoC.setUltimos(nodoC.getContadorH());
                nodoC.noDuplicar();
                lstFollow.add(new Follow(nodoC,nodoC.getContadorH()));
                return nodoC;
            case NUMERAL:
                Nodo nodoNumeral = new Nodo(lstToken.get(i)); i++;
                nodoNumeral.setAnulable(false); hoja++;
                nodoNumeral.setContadorH(hoja);
                nodoNumeral.setPrimeros(nodoNumeral.getContadorH());
                nodoNumeral.setUltimos(nodoNumeral.getContadorH());
                nodoNumeral.noDuplicar();
                lstFollow.add(new Follow(nodoNumeral,nodoNumeral.getContadorH()));
                return nodoNumeral;
            default:
                
                break;
        }
    return null;
    }
    
    public void graficarArbol(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try{
        File miDir = new File (".");
            fichero = new FileWriter(miDir.getAbsolutePath() + "//" + this.nombreExpresion+".dot");
            pw = new PrintWriter(fichero);
            pw.println("digraph {");
            pw.println("node [shape = rectangle, height=0.5, width=1.2];");
            arbol="";
            cuerpoArbolBinario(raiz);
            pw.print(arbol);
            pw.println("}");
        }catch(Exception e){ System.out.println("Algo salio mal al crear la imagen de ="+this.nombreExpresion);}          
        finally {
                try {
                    if (null != fichero)
                        fichero.close();
                } catch (Exception e2) {
                    e2.printStackTrace();
                }
            }
    }
    
    public void cuerpoArbolBinario(Nodo temp){
        if (temp!=null) {
            cuerpoArbolBinario(temp.getIzquierda());
            if (temp.getValor().getValor().equals("|") || temp.getValor().getValor().equals(">") || temp.getValor().getValor().equals("<") || temp.getValor().getValor().equals("{") || temp.getValor().getValor().equals("}")) {
                arbol+= "\""+ temp.toString()+"\""+"[shape = record, label = \"P: "+temp.getPrimeros().toString()+"|{"+temp.isAnulable()+" |\\"+temp.getValor().getValor()+"}|U: "+temp.getUltimos()+" \"] \n";
            }else if(temp.getContadorH()>0){
                arbol+= "\""+ temp.toString()+"\""+"[shape = record, label = \"P: "+temp.getPrimeros().toString()+"|{"+temp.isAnulable()+" |"+temp.getValor().getValor()+"}|U: "+temp.getUltimos()+" | Hoja: "+temp.getContadorH()+" \"] \n";
            }            
            else{arbol+= "\""+ temp.toString()+"\""+"[shape = record, label = \"P: "+temp.getPrimeros().toString()+"|{"+temp.isAnulable()+" |"+temp.getValor().getValor()+"}|U: "+temp.getUltimos()+" \"] \n";}
           if(temp.getDerecha()!=null){
               arbol += "\""+temp.toString()+"\""+" -> "+"\""+temp.getDerecha().toString()+"\" \n";
           }
           if(temp.getIzquierda()!=null){
               arbol += "\""+temp.toString()+"\""+" -> "+"\""+temp.getIzquierda().toString()+"\" \n";
           } 
           cuerpoArbolBinario(temp.getDerecha());
        }
    }
    
    //Metodo para generar la imagen
    public  void creacionDibujo(String name){
        try{

            String dotPath = "C:\\Program Files (x86)\\Graphviz2.38\\bin\\dot.exe";
            File miDir = new File (".");
            System.out.println(miDir.getCanonicalPath());
            System.out.println(miDir.getAbsoluteFile());
            System.out.println(miDir.getPath());
            String fileInputPath = miDir.getAbsolutePath()+"\\"+ name +".dot";
            String fileOutputPath = miDir.getAbsolutePath()  +"\\"+name+".png";

            String tParam = "-Tpng";
            String tOParam = "-o";

            String[] cmd = new String[5];
            cmd[0] = dotPath;
            cmd[1] = tParam;
            cmd[2] = fileInputPath;
            cmd[3] = tOParam;
            cmd[4] = fileOutputPath;

            Runtime rt = Runtime.getRuntime();
            
            rt.exec( cmd );

            int x=0;
            File comprobar = new File(miDir.getAbsolutePath()  +"\\"+name+".png");
            while (true){
                x++;
                if(comprobar.exists()){
                    if(comprobar.length() > 100){
                        break;
                    }
                }
           //     System.out.println(x);
            }
            

           // ScrollPaneReport scrollPaneReport = new ScrollPaneReport(fileOutputPath);

            File file = new File(miDir.getAbsolutePath()  +"\\"+name+".png");
            Path path = Paths.get(miDir.getAbsolutePath()  +"\\"+name+".png");
            try {
            Desktop.getDesktop().open(file);
            //archivo.delete();

        } catch (Exception ex) {
                System.out.println("<<<<<------Problema con la imagen---------->>>>>>>");
        }
            if(file.exists()){
            //    Files.delete(path);
            }

            File file2 = new File(miDir.getAbsolutePath()  +"\\"+name+".txt");
            Path path2 = Paths.get(miDir.getAbsolutePath()  +"\\"+name+".txt");
            if(file2.exists()){
             //   Files.delete(path2);
            }


        } catch (Exception ex) {
            ex.printStackTrace();
        } finally {
        }

    }
    
    //Metodo para graficar tabla de follow
    public void graficarTablaFollow(){
        FileWriter fichero = null;
        PrintWriter pw = null;
        try{
        File miDir = new File (".");
            fichero = new FileWriter(miDir.getAbsolutePath() + "//" + this.nombreTablaFollow+".dot");
            pw = new PrintWriter(fichero);
            pw.println("digraph G {");
            pw.println("node[ shape = none, fontname = \"Arial\" ];");
            pw.println("set1[ label=<");
            pw.println("<TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"4\">");
            pw.println("<TR>");
            pw.println("<TD>Terminal</TD>");
            pw.println("<TD>Hoja</TD>");
            pw.println("<TD>Follow</TD>");
            pw.println("");
            pw.println("</TR>");
            follow="";
            for (int k = 0; k < lstFollow.size(); k++) {
            follow+="<TR>\n";
            follow+="<TD>";                
                if (lstFollow.get(k).getTerminal().getValor().getValor().equals("|") || lstFollow.get(k).getTerminal().getValor().getValor().equals(">") ||lstFollow.get(k).getTerminal().getValor().getValor().equals("<") || lstFollow.get(k).getTerminal().getValor().getValor().equals("{") || lstFollow.get(k).getTerminal().getValor().getValor().equals("}")) {
                 follow+=""+lstFollow.get(k).getTerminal().getValor().getValor().replaceAll(">", "&#62;").replaceAll("<","&#60;");;   
                }else{
                 follow+=lstFollow.get(k).getTerminal().getValor().getValor();;
                }        
            follow+="</TD>\n";
            follow+="<TD>"; 
            follow+=lstFollow.get(k).getNumeracion();
            follow+="</TD>\n";
            follow+="<TD>"; 
            follow+=lstFollow.get(k).getSiguientes().toString();
            follow+="</TD>\n";
            follow+="</TR>\n";
                         }
            pw.println(follow);
            pw.println("</TABLE>>];");
            pw.println("}");
        }catch(Exception e){ System.out.println("Algo salio mal al crear la imagen de ="+this.nombreTablaFollow);}          
        finally {
                try {
                    if (null != fichero)
                        fichero.close();
                } catch (Exception e2) {
                    e2.printStackTrace();
                }
            }
    }
    
    
    public String getNombreExpresion() {
        return nombreExpresion;
    }

    public String getNombreTablaFollow() {
        return nombreTablaFollow;
    }

    public ArrayList<Follow> getLstFollow() {
        return lstFollow;
    }
    
    public void tablatransicion(){
        for (int j = 0; j < lstFollow.size(); j++) {
            if (lstFollow.get(j).getTerminal().getValor().getValor()!="#") {
                lstTerminales.add(lstFollow.get(j).getTerminal().getValor().getValor());
            }
        }
        Set<String> tem = new HashSet<>(this.lstTerminales);
        this.lstTerminales.clear();
        this.lstTerminales.addAll(tem);
        
        for (int j = 0; j < lstTerminales.size(); j++) {
            lstT.add(new Terminal(lstTerminales.get(j)));
        }
        lstTransiciones.add(new Transiciones(estados,lstT,raiz.getPrimeros(),false)); //Se crea el estado inical
        
    }
    
    public void interaciones(int o){
        for (int j = 0; j < lstTransiciones.get(o).getAlcansables().size(); j++) {
          String adonde = lstFollow.get(lstTransiciones.get(o).getAlcansables().get(j)).getTerminal().getValor().getValor();
            for (int k = 0; k < lstTransiciones.get(o).getTerminal().size(); k++) {
                if (lstTransiciones.get(o).getTerminal().get(k).getSimbolo().equals(adonde)) {
                    lstTransiciones.get(o).getTerminal().get(k).getEstado().addAll(lstFollow.get(lstTransiciones.get(o).getAlcansables().get(j)).getSiguientes());
                    lstTransiciones.get(o).getTerminal().get(k).noDuplicar();
                }
            }         
        }
    }
    
    
    
    
}
