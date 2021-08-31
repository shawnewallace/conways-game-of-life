function GameController(props) {
	return (
		<div>
			<span>Controller</span><br />

			<input
				name="autoTick"
				type="checkbox"
				defaultChecked={props.autoTick}
				onChange={props.onToggleAutoTick}>
			</input>Auto-tick<br />

			<button type="button" className="btn btn-light" onClick={props.onTick}>Tick</button>
			<button type="button" className="btn btn-light" onClick={props.onResetGame}>Reset</button>


			<div>Num Ticks: {props.numTicks}</div>
			<div>Population: {props.population}</div>
		</div>
	);
}

export default GameController;