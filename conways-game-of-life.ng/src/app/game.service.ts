import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Game, GameApiRequest } from './game';
import { BoardGenerator } from './board_generator';

import { BOARD_GENERATORS } from './mock_generators';
// tslint:disable-next-line:import-blacklist
import { Observable } from 'rxjs';
import { resetFakeAsyncZone } from '../../node_modules/@angular/core/testing';

import { environment } from '../environments/environment';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' })
};

// const rootUrl = 'https://localhost:5001/api';
// const rootUrl = 'https://20b4yyylc8.execute-api.us-east-2.amazonaws.com/dev';
const rootUrl = environment.apiEndpoint;


@Injectable()
export class GameService {
  serviceUrls = 'assets/config.json';

  constructor(private http:  HttpClient) { }

  getGenerators(): Observable<BoardGenerator[]> {
    const path = `${rootUrl}/generators`;
    console.log(`GET from ${path}`);

    return this.http.get<BoardGenerator[]>(path, httpOptions);
  }

  createNewGame(width: number, height: number, fillFactor: number, generator: string): Observable<Game> {
    const path = `${rootUrl}/game`;
    console.log(`POST to ${path}`);
    console.log(`Creating a new game: ${width}x${width}-${fillFactor} ${generator}`);

    const body = {
      width: width,
      height: height,
      fillFactor: fillFactor,
      generator: generator
    };

    console.log(body);

    return this.http.post<Game>(`${rootUrl}/game`, body, httpOptions);
  }

  tick(game: Game) {
    const path = `${rootUrl}/game/tick`;
    console.log(`POST to ${path}`);

    console.log('Ticking board:');
    console.log(game);

    return this.http.post<Game>(`${rootUrl}/game/tick`, game, httpOptions);
  }
}
