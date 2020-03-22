/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Objetos;

import java.util.ArrayList;

/**
 *
 * @author Steven Sis
 */
public class Transiciones {
    private int estado;
    private ArrayList<Terminal> terminal;
    private ArrayList<Integer> alcansables;
    private boolean aceptacion;
    public int getEstado() {
        return estado;
    }

    public void setEstado(int estado) {
        this.estado = estado;
    }

    public ArrayList<Terminal> getTerminal() {
        return terminal;
    }

    public void setTerminal(ArrayList<Terminal> terminal) {
        this.terminal = terminal;
    }

    public ArrayList<Integer> getAlcansables() {
        return alcansables;
    }

    public void setAlcansables(ArrayList<Integer> alcansables) {
        this.alcansables = alcansables;
    }

    public Transiciones(int estado, ArrayList<Terminal> terminal, ArrayList<Integer> alcansables, boolean aceptacion) {
        this.estado = estado;
        this.terminal = terminal;
        this.alcansables = alcansables;
        this.aceptacion = aceptacion;
    }

    public Transiciones(int estado, ArrayList<Integer> alcansables, boolean aceptacion) {
        this.estado = estado;
        this.alcansables = alcansables;
        this.aceptacion = aceptacion;
    }

    public Transiciones() {
    }
    
}
