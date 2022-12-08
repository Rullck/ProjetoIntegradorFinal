import 'package:flutter/material.dart';
import 'package:helloworld/http.dart';
import 'package:mysql1/mysql1.dart';
import 'dart:async';
import 'conn.dart';

Future main() async {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({key});

  static const String _title = 'AvaliaAula';

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: _title,
      home: Scaffold(
        appBar: AppBar(title: const Text(_title)),
        body: const MyStatefulWidget(),
      ),
    );
  }
}

class MyStatefulWidget extends StatefulWidget {
  const MyStatefulWidget({key});

  @override
  State<MyStatefulWidget> createState() => _MyStatefulWidgetState();
}

class _MyStatefulWidgetState extends State<MyStatefulWidget> {
  final myController = TextEditingController();
  int numStars = 0;
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  var _myColorOne = Colors.grey;
  var _myColorTwo = Colors.grey;
  var _myColorThree = Colors.grey;
  var _myColorFour = Colors.grey;
  var _myColorFive = Colors.grey;

  @override
  Widget build(BuildContext context) {
    return Form(
      key: _formKey,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: <Widget>[
          Container(
            padding: EdgeInsets.all(16),
            child: new Center(
              child: new Container(
                height: 10.0,
                width: 500.0,
                child: new Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: <Widget>[
                    new IconButton(
                      icon: new Icon(Icons.star),
                      onPressed: () => setState(() {
                        numStars = 1;
                        _myColorOne = Colors.orange;
                        _myColorTwo = Colors.grey;
                        _myColorThree = Colors.grey;
                        _myColorFour = Colors.grey;
                        _myColorFive = Colors.grey;
                      }),
                      color: _myColorOne,
                    ),
                    new IconButton(
                      icon: new Icon(Icons.star),
                      onPressed: () => setState(() {
                        numStars = 2;
                        _myColorOne = Colors.orange;
                        _myColorTwo = Colors.orange;
                        _myColorThree = Colors.grey;
                        _myColorFour = Colors.grey;
                        _myColorFive = Colors.grey;
                      }),
                      color: _myColorTwo,
                    ),
                    new IconButton(
                      icon: new Icon(Icons.star),
                      onPressed: () => setState(() {
                        numStars = 3;
                        _myColorOne = Colors.orange;
                        _myColorTwo = Colors.orange;
                        _myColorThree = Colors.orange;
                        _myColorFour = Colors.grey;
                        _myColorFive = Colors.grey;
                      }),
                      color: _myColorThree,
                    ),
                    new IconButton(
                      icon: new Icon(Icons.star),
                      onPressed: () => setState(() {
                        numStars = 4;
                        _myColorOne = Colors.orange;
                        _myColorTwo = Colors.orange;
                        _myColorThree = Colors.orange;
                        _myColorFour = Colors.orange;
                        _myColorFive = Colors.grey;
                      }),
                      color: _myColorFour,
                    ),
                    new IconButton(
                      icon: new Icon(Icons.star),
                      onPressed: () => setState(() {
                        numStars = 5;
                        _myColorOne = Colors.orange;
                        _myColorTwo = Colors.orange;
                        _myColorThree = Colors.orange;
                        _myColorFour = Colors.orange;
                        _myColorFive = Colors.orange;
                      }),
                      color: _myColorFive,
                    ),
                  ],
                ),
              ),
            ),
          ),
          TextFormField(
            decoration: const InputDecoration(
              hintText: 'Insira seu comentário',
            ),
            controller: myController,
          ),
          Padding(
            padding: const EdgeInsets.symmetric(vertical: 16.0),
            child: ElevatedButton(
              onPressed: () {
                conn();
                connhttp();
                // Validate will return true if the form is valid, or false if
                // the form is invalid.
                print(myController.value.text + ' ' + numStars.toString());
              },
              child: const Text('Avaliar'),
            ),
          ),
        ],
      ),
    );
  }
}
