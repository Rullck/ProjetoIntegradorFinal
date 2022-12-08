import 'dart:convert' as convert;

import 'package:http/http.dart' as http;

void connhttp() async {
  // This example uses the Google Books API to search for books about http.
  // https://developers.google.com/books/docs/overview

  // Await the http get response, then decode the json-formatted response.
  var client = http.Client();
  try {
    var response = await client.post(
        Uri.https('20.226.108.178..5001', 'Avaliacao/Enviar'),
        body: {"comentario": "carlos", "avaliacao1": 4, "idDiciplina": 3});
    var decodedResponse =
        convert.jsonDecode(convert.utf8.decode(response.bodyBytes)) as Map;
    var uri = Uri.parse(decodedResponse['uri'] as String);
    print(await client.get(uri));
  } finally {
    client.close();
  }
}
