import nfl_data_py as nfl
import json
from pathlib import Path

def fetch_colts_passing_yards():
    # Fetch weekly data for the 2023 season
    week_data = nfl.import_weekly_data([2023])
    
    # Filter data for the Indianapolis Colts (team abbreviation 'IND')
    colts_data = week_data[week_data['recent_team'] == 'IND']
    
    # Filter for quarterback position and passing yards
    colts_qb_data = colts_data[colts_data['position'] == 'QB']
    colts_qb_passing_yards = colts_qb_data.to_dict(orient='records')

    # Save the data to a JSON file in a specific directory
    output_dir = Path(__file__).resolve().parent / 'PythonScripts'
    output_dir.mkdir(parents=True, exist_ok=True)
    output_path = output_dir / 'colts_qb_passing_yards.json'
    
    with open(output_path, 'w') as json_file:
        json.dump(colts_qb_passing_yards, json_file, indent=4)

if __name__ == "__main__":
    fetch_colts_passing_yards()