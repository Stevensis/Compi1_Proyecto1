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
public class Terminal {
    private String simbolo;
    private ArrayList<Integer> estado;

    public String getSimbolo() {
        return simbolo;
    }

    public void setSimbolo(String simbolo) {
        this.simbolo = simbolo;
    }

    public ArrayList<Integer> getEstado() {
        return estado;
    }

    public void setEstado(ArrayList<Integer> estado) {
        this.estado = estado;
    }

    public Terminal(String simbolo, ArrayList<Integer> estado) {
        this.simbolo = simbolo;
        this.estado = estado;
    }

    public Terminal(String simbolo) {
        this.simbolo = simbolo;
    }
    public void noDuplicar() {
        Set<Integer> remplazar = new HashSet<>(this.estado);
        this.estado.clear();
        this.estado.addAll(remplazar);
    }
    
}
