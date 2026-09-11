# MultipleServices – create-order-eksempel

Løsningsforslag til dag 4, slide 78–80. Begge API-projekter bruger .NET 10 og Scalar.
Eksemplet fokuserer på REST-kald mellem containere, miljøvariabler og Docker Compose.

## Start

Kør fra repositoryets rod på branchen MultipleServices:

```powershell
docker compose up --build -d
```

- Scalar: http://localhost:8080/scalar
- Start flowet: GET http://localhost:8080/OrderService
- OpenAPI: http://localhost:8080/openapi/v1.json

Vent til API'erne er startet, før du kalder flowet. Du kan se output med:

```powershell
docker compose logs -f
```

Ctrl+C afslutter logvisningen. Stop containerne med `docker compose down`.
API_PORT kan bruges til at vælge en anden værtsport end 8080.

## Hvad sker der?

Indgangsservicen læser urlsForExternal og kalder consumer, restaurant, accounting,
kitchen og delivery i rækkefølge. Hver service returnerer teksten fra returnValue.
Indgangsservicen skriver svarene i sin log og returnerer til sidst en bekræftelse.

Der bruges kun to images: multiple_docker og docker_service. De fem bagvedliggende
services bruger samme image med forskellige miljøvariabler. Kun indgangsservicen
har en eksponeret værtsport; interne kald bruger Compose-servicenavne og port 80.

Som i øvelsens forenklede forslag bruges GET uden ordreparametre til at demonstrere flowet.
Der er ingen database, healthchecks eller automatisk fejlhåndtering i eksemplet.

Compose bygger docker_service via consumer �n gang. De �vrige fire services genbruger dette image.
