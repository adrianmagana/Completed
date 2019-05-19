package com.example.airuser.soyf10;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.toolbox.Volley;
import com.facebook.AccessToken;

import org.json.JSONException;
import org.json.JSONObject;

/**
 * Created by William on 4/26/2017.
 */

public class FacebookRegister extends AppCompatActivity{
    Button bRegister;
    EditText etName, etAge,etUsername, etPassword;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_facebook_register);

        etUsername = (EditText) findViewById(R.id.etUsername);
        etPassword = (EditText) findViewById(R.id.etPassword);
        bRegister = (Button) findViewById(R.id.bRegister);

        bRegister.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                AccessToken accessToken = AccessToken.getCurrentAccessToken();
                String facebookID = accessToken.getUserId();
                String username = etUsername.getText().toString();
                String password = etPassword.getText().toString();

                Response.Listener<String> responseListener = new Response.Listener<String>() {
                    public void onResponse(String response) {
                        try {
                            JSONObject jsonResponse = new JSONObject(response);
                            boolean success = jsonResponse.getBoolean("success");

                            if (success) {
                                Intent intent = new Intent(FacebookRegister.this, MainActivity.class);
                                intent.putExtra("fb", false);
                                FacebookRegister.this.startActivity(intent);
                            } else {
                                AlertDialog.Builder builder = new AlertDialog.Builder(FacebookRegister.this);
                                builder.setMessage("Register Failed")
                                        .setNegativeButton("Retry", null)
                                        .create()
                                        .show();
                            }
                        } catch (JSONException e) {
                            e.printStackTrace();
                        }

                    }

                };

                FacebookRegisterRequest registerRequest = new FacebookRegisterRequest(username, password, facebookID, responseListener);
                RequestQueue queue = Volley.newRequestQueue(FacebookRegister.this);
                queue.add(registerRequest);
            }

        });
    }
}
