namespace EssentialsExtended {
	public static partial class ESX {
		public static partial class UI {
			public class MenuElement {
				public dynamic Raw;

				public MenuElement(dynamic data) => Raw = data;

				public MenuElement(dynamic label, dynamic value, dynamic customdata = null, string type = "default") {
					Raw = new System.Dynamic.ExpandoObject();
					Raw.label = label;
					Raw.value = value;
					Raw.type = type;
					Custom = customdata;
				}

				public MenuElement() {
					Raw = new System.Dynamic.ExpandoObject();
					Raw.label = new System.Dynamic.ExpandoObject();
					Raw.value = new System.Dynamic.ExpandoObject();
					Raw.type = "default";

					Custom = new System.Dynamic.ExpandoObject();
				}

				public dynamic Label {
					get => Raw.label;
					set => Raw.label = value;
				}

				public dynamic Value {
					get => Raw.value;
					set => Raw.value = value;
				}

				public string Type {
					get => Raw.type;
					set => Raw.type = value;
				}

				public dynamic Custom {
					get; set;
				}
			}
		}
	}
}