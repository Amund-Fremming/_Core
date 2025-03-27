# Tasklist

## Backend

- Se p� User, kan v�re det ikke g�r � lage koblings felles koblingstabell for GuesUser og User
- AddPlayer finnes ikke i game lenger, ta tilbake?? eller kj�re for speed

- Skrive changelog!!
- utvide result pattern til � ha flere messages eller bare en, utvide tli � ha trace og metode for � hente dden �verste
- endre fra early return til liste med feilmeldinger ???
- endepunkt for � oppdatere spillers activity
- endepunkt for � sjekke om spiller finnes
- endepunkt for � gj�re spiller inactive med disconnect
- DDD methods on SpinGame
- Try to combine all assemblies in presenation to get api ts generation
- Performance test AddPlayer DDD vs service layer
- Admin dashboard
	- Toggle notifications on app opening
	- Delete game possibility
	- Se antall aktive brukere n�, denne uken, denne m�neden

## Frontend
- Endre InfoModal til � eksportere to funksjoner, toggle error og ikke, ikke bruk bool inn, det er vanskelig � forst�
- Providers
	- Global state
	- Service provider
	- Connection
		- Must have a api call to remove the player from the game (set to inactive)
	- Game specific
- Analysis
	- Firebase

## DB Optimalisering
- Pooling
- Indeksering
- Cache
- Host db with backend
