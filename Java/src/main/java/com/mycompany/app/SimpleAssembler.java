package com.mycompany.app;

import javafx.application.Application;

import java.util.*;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class SimpleAssembler {
    public static Map<String, Integer> interpret(String[] program) {

        Map<String, Integer> registers = new HashMap<>();

        List<Command> commands = Stream.of(program)
                .map(SimpleAssembler::ParseCommandText)
                .collect(Collectors.toList());


        for (int programCounter = 0; programCounter < commands.size(); ) {
            Command command = commands.get(programCounter);
            int jump = command.Execute(registers);

            programCounter += jump;
        }

        return registers;
    }

    private static Command ParseCommandText(String commandText) {
        String[] parts = commandText.split(" ");
        switch (parts[0]) {
            case "mov":
                return new MoveCommand(parts[1], parts[2]);

            case "inc":
                return new IncCommand(parts[1]);

            case "dec":
                return new DecCommand(parts[1]);

            case "jnz":
                return new JnzCommand(parts[1], parts[2]);

            default:
                throw new RuntimeException("Invalid command: " + commandText);
        }
    }

    public static abstract class Command {
        public abstract int Execute(Map<String, Integer> registers);
    }

    private static class MoveCommand extends Command {
        private final String x;
        private final String y;

        MoveCommand(String x, String y) {
            this.x = x;
            this.y = y;
        }

        @Override
        public int Execute(Map<String, Integer> registers) {
            try {
                registers.put(x,Integer.parseInt(y));
            } catch (NumberFormatException e) {
                Integer val = registers.get(y);
                registers.put(x, val);
            }

            return 1;
        }
    }

    private static class IncCommand extends Command {
        private String x;

        IncCommand(String x) {

            this.x = x;
        }

        @Override
        public int Execute(Map<String, Integer> registers) {
            int val = registers.get(x);
            val++;
            registers.put(x, val);

            return 1;
        }
    }

    public static class JnzCommand extends Command {
        private final String x;
        private final String y;

        public JnzCommand(String x, String y) {
            this.x = x;
            this.y = y;
        }

        @Override
        public int Execute(Map<String, Integer> registers) {
            Integer value;
            try {
                value = Integer.parseInt(x);
            } catch (NumberFormatException e) {
                value = registers.get(x);
            }

            if (value == 0){
                return 1;
            }
            else {
                try {
                    return Integer.parseInt(y);
                } catch (NumberFormatException e) {
                    return registers.get(y);
                }
            }
        }
    }

    private static class DecCommand extends Command {
        private String x;

        DecCommand(String x) {
            this.x = x;
        }

        @Override
        public int Execute(Map<String, Integer> registers) {
            Integer val = registers.get(x);
            val--;
            registers.put(x, val);

            return 1;
        }
    }
}