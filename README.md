# DevTrack - (Batch4-Team2)


# Dashboard ([Click Here](https://docs.google.com/spreadsheets/d/1xR6lKH0TGh9GXPU_OSNLcdOhsllZe78vo3er4UQCNBg/edit?ts=60051279#gid=1041983261))

## SQLite Update Database Command
- `dotnet ef database update --project DevTrack.TrackerWorkerService --context DevTrackContext`

## SqlServer Update Database Command
- `dotnet ef database update --project DevTrack.Web --context ApplicationDbContext`
- `dotnet ef database update --project DevTrack.Web --context DevTrackWebContext`




### Before Run Project, Make sure
- Set Startup Project
- Change connection string followed by your machine in `appsettings.json`
