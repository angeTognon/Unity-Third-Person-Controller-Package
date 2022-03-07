import 'dart:io';

void main() {
  stdout.writeln("Please enter your name : ");
  var name = stdin.readLineSync();
  print("votre nom est $name");
  
}