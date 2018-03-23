package com.mycompany.app;

import org.junit.Test;
import static org.junit.Assert.assertEquals;
import java.util.HashMap;
import java.util.Map;

// https://www.codewars.com/kata/simple-assembler-interpreter/train/java
public class SolutionTest {
    @Test
    public void simple_0_move_inc() {
        String[] program = new String[]{"mov a 5","inc a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 6);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void simple_0_move_dec() {
        String[] program = new String[]{"mov a 5","dec a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 4);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void simple_0_move_jump() {
        String[] program = new String[]{"mov a 5","jnz 10 2","dec a", "dec a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 4);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void move_register_value() {
        String[] program = new String[]{"mov a 5","mov b a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 5);
        out.put("b", 5);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void simple_0_move_jump_skip_on_zero() {
        String[] program = new String[]{"mov a 0","jnz a 2","dec a", "dec a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", -2);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void simple_0_move_jump_by_register() {
        String[] program = new String[]{"mov a 2","jnz a a","dec a", "dec a"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 1);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void jump_loop() {
        String[] program = new String[]{"mov a 2","dec a","jnz a -1"};

        Map<String, Integer> out = new HashMap<>();
        out.put("a", 0);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void JumpCommand_when_zero(){
        SimpleAssembler.JnzCommand command = new SimpleAssembler.JnzCommand("0", "10");
        assertEquals(1, command.Execute(new HashMap<>()));
    }

    @Test
    public void JumpCommand_when_number(){
        SimpleAssembler.JnzCommand command = new SimpleAssembler.JnzCommand("1", "10");
        assertEquals(10, command.Execute(new HashMap<>()));
    }

    @Test
    public void JumpCommand_when_register_zero(){
        HashMap<String, Integer> registers = new HashMap<>();
        registers.put("a", 0);

        SimpleAssembler.JnzCommand command = new SimpleAssembler.JnzCommand("a", "10");
        assertEquals(1, command.Execute(registers));
    }

    @Test
    public void JumpCommand_when_register_number(){
        HashMap<String, Integer> registers = new HashMap<>();
        registers.put("a", 5);

        SimpleAssembler.JnzCommand command = new SimpleAssembler.JnzCommand("a", "10");
        assertEquals(10, command.Execute(registers));
    }

    @Test
    public void simple_1() {
        String[] program = new String[]{"mov a 5","inc a","dec a","dec a","jnz a -1","inc a"};
        Map<String, Integer> out = new HashMap<String, Integer>();
        out.put("a", 1);
        assertEquals(out, SimpleAssembler.interpret(program));
    }

    @Test
    public void simple_2() {
        String[] program = new String[]{"mov a -10","mov b a","inc a","dec b","jnz a -2"};
        Map<String, Integer> out = new HashMap<String, Integer>();
        out.put("a", 0);
        out.put("b", -20);
        assertEquals(out, SimpleAssembler.interpret(program));
    }
}