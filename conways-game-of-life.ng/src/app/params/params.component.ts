import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Game } from '../game';
import { BoardGenerator } from '../board_generator';

@Component({
  selector: 'app-params',
  templateUrl: './params.component.html',
  styleUrls: ['./params.component.css']
})
export class ParamsComponent implements OnInit {

  @Input() generators: BoardGenerator[];
  @Input() width: number;
  @Input() height: number;
  @Input() fillFactor: number;
  @Input() selectedGenerator: string;

  @Output() completed: EventEmitter<Game> = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  complete() {
    const result = new Game();
    result.height = this.height;
    result.width = this.width;
    result.fillFactor = this.fillFactor;
    result.generator = this.selectedGenerator;

    this.completed.emit(result);
  }
}
