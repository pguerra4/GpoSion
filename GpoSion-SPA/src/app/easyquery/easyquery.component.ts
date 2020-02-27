import { Component, AfterViewInit } from "@angular/core";
import { EqContext, i18n } from "@easyquery/core";
import { EqViewOptions, AdvancedSearchView } from "@easyquery/ui";
import "@easyquery/enterprise";
import { environment } from "src/environments/environment";

@Component({
  selector: "app-easyquery",
  templateUrl: "./easyquery.component.html",
  styleUrls: ["./easyquery.component.css"]
})
export class EasyqueryComponent implements AfterViewInit {
  private QUERY_KEY = "easyquerycomponent-query";

  private context: EqContext;

  private view: AdvancedSearchView;
  baseUrl = environment.apiUrl;

  constructor() {}

  ngAfterViewInit() {
    i18n.setCurrentLocale("es");
    const options: EqViewOptions = {
      enableExport: true,
      loadModelOnStart: true,
      loadQueryOnStart: false,

      //Middlewares endpoint
      endpoint: this.baseUrl + "easyquery",

      handlers: {
        onError: error => {
          console.error(error.action + " error:\n" + error.text);
        }
      },
      widgets: {
        entitiesPanel: {
          showCheckboxes: true
        },
        columnsPanel: {
          allowAggrColumns: true,
          allowCustomExpressions: true,
          attrElementFormat: "{entity} {attr}",
          titleElementFormat: "{attr}",
          showColumnCaptions: true,
          adjustEntitiesMenuHeight: false,
          customExpressionText: 2,
          showPoweredBy: false,
          menuOptions: {
            showSearchBoxAfter: 30,
            activateOnMouseOver: true
          }
        },
        queryPanel: {
          showPoweredBy: false,
          alwaysShowButtonsInPredicates: false,
          allowParameterization: true,
          allowInJoinConditions: true,
          autoEditNewCondition: true,
          buttons: {
            condition: ["menu"],
            predicate: ["addCondition", "addPredicate", "enable", "delete"]
          },
          menuOptions: {
            showSearchBoxAfter: 20,
            activateOnMouseOver: true
          }
        }
      },
      result: {
        showChart: true
      }
    };

    this.view = new AdvancedSearchView();
    this.context = this.view.getContext();

    this.view
      .getContext()
      .useEnterprise("0uo6BQcy_pU-eeWAgzISFG32v1ACiIboqH0qzo35snsBFJKG1WV");
    this.view.init(options);

    this.context.addEventListener("ready", () => {
      const query = this.context.getQuery();

      query.addChangedCallback(() => {
        const data = JSON.stringify({
          modified: query.isModified(),
          query: query.toJSONData()
        });
        localStorage.setItem(this.QUERY_KEY, data);
      });

      //add load query from local storage
      this.loadQueryFromLocalStorage();
    });
  }

  private loadQueryFromLocalStorage() {
    const dataJson = localStorage.getItem(this.QUERY_KEY);
    if (dataJson) {
      const data = JSON.parse(dataJson);
      const query = this.context.getQuery();
      query.loadFromDataOrJson(data.query);
      if (data.modified) {
        query.fireChangedEvent();
      } else {
        this.view.getContext().refreshWidgets();
        this.view.syncQuery();
      }

      setTimeout(() => this.view.executeQuery(), 100);
    }
  }
}
