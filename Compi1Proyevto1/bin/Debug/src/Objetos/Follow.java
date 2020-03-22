/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Objetos;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author Steven Sis
 */
public class Follow {
    private Nodo terminal;
    private int numeracion;
    private ArrayList<Integer> siguientes;

    public Follow(Nodo terminal, int numeracion) {
        this.terminal = terminal;
        this.numeracion = numeracion;
        this.siguientes= new ArrayList();
    }

    public Nodo getTerminal() {
        return terminal;
    }

    public void setTerminal(Nodo terminal) {
        this.terminal = terminal;
    }

    public int getNumeracion() {
        return numeracion;
    }

    public void setNumeracion(int numeracion) {
        this.numeracion = numeracion;
    }

    public ArrayList<Integer> getSiguientes() {
        return siguientes;
    }

    public void setSiguientes(ArrayList<Integer> siguientes) {
        this.siguientes = siguientes;
    }
    
    public void noDuplicar() {
        Set<Integer> remplazar = new HashSet<>(this.siguientes);
        this.siguientes.clear();
        this.siguientes.addAll(remplazar);
    }
}
